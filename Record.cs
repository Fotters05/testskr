using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace TypingSpeed
{
    public class Record
    {
        public Record()
        {

        }

        public Record(string name, int minute, float second)
        {
            this.Name = name;
            this.SymbolPerMinute = minute;
            this.SymbolPerSecond = second;
        }

        public string Name { get; set; }
        public int SymbolPerMinute { get; set; }
        public float SymbolPerSecond { get; set; }

        public Record(string nameArg, int charsPerMinuteArg)
        {
            Name = nameArg;
            SymbolPerMinute = charsPerMinuteArg;
            SymbolPerSecond = (float)charsPerMinuteArg / 60;
        }

        public static List<Record> Serializing(string name, int index)
        {
            string json = File.ReadAllText("C:\\Users\\Fotters\\Desktop\\Record.json");
            List<Record> users = JsonConvert.DeserializeObject<List<Record>>(json);
            Record user = new Record(name, index);
            users.Add(user);

            json = JsonConvert.SerializeObject(users);
            File.WriteAllText("C:\\Users\\Fotters\\source\\repos\\testskr\\record.json", json);

            return users;
        }
    }
}