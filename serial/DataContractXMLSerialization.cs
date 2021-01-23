﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;

namespace serial
{
    public static class DataContractXMLSerialization
    {
        public static void  SerializeToFile<T>(T obj, string fileName)
        {
            using var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            DataContractSerializer s = new DataContractSerializer(typeof(T));
            s.WriteObject(fileStream, obj);
        }

        public static T DeserializeFromFile<T>(string fileName)
        {
            using var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            DataContractSerializer s = new DataContractSerializer(typeof(T));

            return (T)s.ReadObject(fileStream);
        }
    }

    
}
