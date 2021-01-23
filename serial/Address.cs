using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace serial
{
    [Serializable]
    [DataContract]
    public class Address : ICloneable
    {
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string City { get; set; }

        public Address(string street, string postalCode, string city)
        {
            Street = street; PostalCode = postalCode; City = city;
        }

        public override string ToString() => $"(HashCode: {this.GetHashCode()}: {Street}, {PostalCode} {City})";

        object ICloneable.Clone() => this.MemberwiseClone();
        public Address Clone() => (Address)this.MemberwiseClone();
    }
}
