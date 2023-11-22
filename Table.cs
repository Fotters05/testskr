using Newtonsoft.Json;
namespace TypingSpeed
  
{
    public class Table
    {
        static List<Record> records = new List<Record>();

        public bool AddItem(string name, int minute, float second)
        {
            if (!records.Any(item => item.Name == name))
            {
                records.Add(new Record(name, minute, second));
                return true;
            }
            return false;
        }
        static void AddRecords(Record record)
        {
            records.Add(record);
        }

        public static void Serialize()
        {
            string json = JsonConvert.SerializeObject(records);

            File.WriteAllText("C:\\Users\\Fotters\\Desktop\\Record.json", json);

        }


        public void WriteReccord()
        {
            foreach (Record record in records)
            {
                Console.WriteLine("имя: " + record.Name, "скорость в минутах: " + record.SymbolPerMinute, "скорость в секундах" + record.SymbolPerSecond);
            }
        }
    }
}