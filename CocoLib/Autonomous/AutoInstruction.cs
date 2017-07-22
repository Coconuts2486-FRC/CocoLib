using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace CocoLib.Autonomous
{
    public class AutoInstruction
    {
        public List<IQuantity> Commands = new List<IQuantity>();

        public void AddToList(IQuantity command)
        {
            Commands.Add(command);
        }

        public override string ToString()
        {
            StringWriter sw = new StringWriter();
            for(int i = 0; i < Commands.Count; i++)
            {
                IQuantity q = Commands.ElementAt(i);
                q.Run();
            }
            return sw.ToString();
        }

        public void Save(string directory)
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(directory, json);
        }
    }
}
