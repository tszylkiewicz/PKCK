using System.Runtime.Serialization;

namespace PKCK.Model
{
    [DataContract(Namespace = "")]
    public enum Genre
    {
        [EnumMember]
        Action,
        [EnumMember]
        SciFi,
        [EnumMember]
        Horror,
        [EnumMember]
        Comedy,
        [EnumMember]
        Drama,
        [EnumMember]
        War,
        [EnumMember]
        Fantasy,
        [EnumMember]
        Adventure,
        [EnumMember]
        Thriller
    }
}
