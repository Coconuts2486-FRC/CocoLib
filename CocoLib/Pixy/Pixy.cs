using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPILib;

namespace CocoLib.Pixy
{
    // TODO: Support multiple signatures.
    public class Pixy
    {
        private I2C Port;
        private int Address;
        private List<PixyBlock> _Blocks;

        public int BlockSize { get; set; } = 14;

        /// <summary>
        /// Get the list of blocks from the Pixy.
        /// </summary>
        public List<PixyBlock>  Blocks
        {
            get
            {
                Read();         // Update the block list.
                return _Blocks; // Return the list of blocks.
            }
            private set
            {
                _Blocks = value; 
            }
        }

        public Pixy(int PixyI2CAddress = 0x54)
        {
            try
            {
                Address = PixyI2CAddress;
                Port = new I2C(I2C.Port.Onboard, PixyI2CAddress);
            }
            catch(Exception ex)
            {
                Logging.Functions.AddErrorToLog(ex.Message);
            }
        }

        private void Read()
        {
            _Blocks.Clear(); // Clear the list of all previous blocks.

            byte[] bytes = new byte[64];   // Create a new array to hold the byte data from the Pixy via I2C.
            Port.Read(Address, 64, bytes); // Read the bytes from the Pixy into the array buffer.

            int i = 0;
            for (; i < bytes.Length; i++)
            {
                // Set the bytes to be greater than 0.
                int byte1 = bytes[i];
                if (byte1 < 0)
                    byte1 += 256;

                int byte2 = bytes[i];
                if(byte2 < 0)
                {
                    byte2 += 256;
                }
                
                // Check if the end bytes have been received.
                if (byte1 == 0x55 && byte2 == 0xaa)
                    break;
            }

            if (i == 63)
                return;
            else if (i == 0)
                i += 2;
            
            for(int byteOffset = i; byteOffset < bytes.Length - BlockSize - 1;)
            {
                int byte1 = bytes[byteOffset];

                if (byte1 < 0)
                    byte1 += 256;

                int byte2 = bytes[byteOffset++];
                if (byte2 < 0)
                {
                    byte2 += 256;
                }

                // Check if the end bytes have been received.
                if (byte1 == 0x55 && byte2 == 0xaa)
                {
                    byte[] temp = new byte[BlockSize];
                    for (int tempOffset = 0; tempOffset < BlockSize; tempOffset++)
                    {
                        temp[tempOffset] = bytes[byteOffset + tempOffset];
                    }

                    PixyBlock block = BytesToBlock(temp);

                    if (block.Signature == 1)
                    {
                        Blocks.Add(block);
                        byteOffset += BlockSize - 1;
                    }
                    else
                    {
                        byteOffset++;
                    }
                }

                else
                {
                    byteOffset++;
                }
            }
        }

        // TODO: Try changing type from Int32 to Int16. Two bytes = Int16.
        private PixyBlock BytesToBlock(byte[] bytes)
        {
            PixyBlock block = new PixyBlock();

            block.Sync = BytesToInt(bytes[1], bytes[0]);
            block.Checksum = BytesToInt(bytes[3], bytes[2]);
            block.Signature = OrBytes(bytes[5], bytes[4]);

            block.CenterX   = ((((int)bytes[7]  & 0xff) << 8) | ((int)bytes[6]  & 0xff));
            block.CenterY   = ((((int)bytes[9]  & 0xff) << 8) | ((int)bytes[8]  & 0xff));
            block.Width     = ((((int)bytes[11] & 0xff) << 8) | ((int)bytes[10] & 0xff));
            block.Height    = ((((int)bytes[13] & 0xff) << 8) | ((int)bytes[12] & 0xff));

            return block;
        }

        public int OrBytes(byte b1, byte b2)
        {
            return (b1 & 0xff) | (b2 & 0xff);
        }


            private int BytesToInt(int b1, int b2)
        {
            if (b1 < 0)
                b1 += 256;

            if (b2 < 0)
                b2 += 256;

            int intValue = b1 * 256;
            intValue += b2;
            return intValue;
        }
    }
}
