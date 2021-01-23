using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace serial
{
    public static class BinarySerialization //nie używać
    {
        public static byte[] SerializeToMemory<T>(T obj)
        {
            using var memStream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(memStream, obj);
            return memStream.ToArray();
        }

        public static T DeserializeFromMemory<T>(byte[] streamObj)
        {
            using var memStream = new MemoryStream(streamObj);
            BinaryFormatter formatter = new BinaryFormatter();
            return (T)formatter.Deserialize(memStream);
        }
    }
}
