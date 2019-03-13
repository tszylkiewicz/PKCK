using System;
using System.Runtime.Serialization;

namespace PKCK.Model
{
    [DataContract(Namespace = "")]
    public class Director
    {
        [DataMember(Order = 0)]
        public string Firstname { get; set; }
        [DataMember(Order = 1)]
        public string Lastname { get; set; }
        [DataMember(Order = 2)]
        public string BirthDate { get; set; }

        public Director(string firstname, string lastname, DateTime birthDate)
        {
            Firstname = firstname;
            Lastname = lastname;
            BirthDate = birthDate.ToString("dd-MM-yyyy");
        }
    }
}
