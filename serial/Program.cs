using System;
using System.Collections.Generic;

namespace serial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Experiments with serialization");
            var dom = new Address("Polna 20", "31-149", "Kraków");
            var km = new Person("KM", 50, dom);
            var mm = new Person("MM", 40, dom);
            mm.Spouse = km;
            km.Spouse = mm;
            var gm = new Person("GM", 12, dom);
            var jm = new Person("JM", 25, new Address("Krótka 2", "30-250", "Kraków"));
            var childs = new HashSet<Person> { gm, jm };
            km.Childrens = mm.Childrens = childs;


            //serializacja binarna
            //var tab = BinarySerialization.SerializeToMemory<Person>(km);
            //var km1 = BinarySerialization.DeserializeFromMemory<Person>(tab);

            DataContractXMLSerialization.SerializeToFile<Person>(km, "aaa.xml");
            var km1 = DataContractXMLSerialization.DeserializeFromFile<Person>("aaa.xml");

            Console.WriteLine(km);
            Console.WriteLine(km1);


        }
    }
}
