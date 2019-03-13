using System.Collections.Generic;
using System.Runtime.Serialization;
using PKCK.Model;

namespace PKCK
{
    [DataContract(IsReference = true, Namespace = "")]
    public class Collection
    {
        [DataMember]
        public List<Movie> Movies { get; set; }
        [DataMember]
        public List<Director> Directors { get; set; }
    }
}
