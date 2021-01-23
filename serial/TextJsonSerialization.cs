using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace serial
{
    public static class TextJsonSerialization
    {

        public static void  SerializeWithRefToFile<T>(T obj, string filename)
        {
            var options = new JsonSerializerOptions
            {
                Reference
                WriteIndented = true
            };

            var s = JsonSerializer.Serialize<T>(obj, options);
            File.WriteAllText(filename, s);
        }

        public static T DeserializeWithRefFromFile<T>(string filename)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            string json = File.ReadAllText(filename);
            return (T)JsonSerializer.Deserialize<T>(json, options);
        }
    }
}
