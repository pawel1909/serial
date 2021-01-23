using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace serial
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class Person : ICloneable
    {
        [DataMember (Order = 1)]
        public string Name { get; set; }
        [DataMember (Order = 2)]
        public int Age { get; set; }
        [DataMember (Order = 3)]
        public Address Address { get; set; }
        [DataMember]
        public Person Spouse { get; set; }
        [DataMember]
        public ICollection<Person> Childrens { get; set; } = null;


        public Person(string name, int age, Address address = null, Person spouse = null)
        {
            Name = name;
            Age = age;
            Address = address;
            Spouse = spouse;
        }

        public Person(Person other) : this(other.Name, other.Age, other.Address, other.Spouse)
        { }

        public override string ToString() => $"id: {GetHashCode()} -> name: {Name}, age: {Age}, address: {Address}";

        object ICloneable.Clone() => this.MemberwiseClone();
        public Person Clone() => (Person)this.MemberwiseClone();

        public Person DeepClone()
        {
            Person clone = this.Clone();
            clone.Address = this.Address.Clone();
            clone.Spouse = null;
            clone.Childrens = null;
            return clone;
        }

    }
}
