using System.Collections.Generic;
using System.Runtime.Serialization;
using PKCK.Model;

namespace PKCK
{
    [DataContract(IsReference = true)]
    public class ModelCollection
    {
        [DataMember]
        public List<Movie> Movies { get; set; }
        [DataMember]
        public List<Director> Directors { get; set; }
    }
}
