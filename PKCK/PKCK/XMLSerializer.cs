using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace PKCK
{
    public class XMLSerializer
    {
        public void Serialize<T>(T obj, string path)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(T));
            using (XmlWriter writer = XmlWriter.Create(File.Create(path), new XmlWriterSettings() { NewLineChars = "\r\n", Indent = true, IndentChars = " " }))
            {
                serializer.WriteObject(writer, obj);
            }
        }
    }
}