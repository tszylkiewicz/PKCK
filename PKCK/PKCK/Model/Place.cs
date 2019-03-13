using System.Runtime.Serialization;

namespace PKCK.Model
{
    [DataContract(Namespace = "")]
    public enum Place
    {
        [EnumMember]
        USA,
        [EnumMember]
        Poland,
        [EnumMember]
        UK,
        [EnumMember]
        Canada
    }
}
