using System;
using System.Runtime.Serialization;

namespace PKCK.Model
{
    public class Director
    {
        [DataMember]
        public String Firstname { get; set; }
        [DataMember]
        public String Lastname { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
    }
}
