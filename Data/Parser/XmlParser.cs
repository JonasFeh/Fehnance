using System.Xml.Serialization;

namespace Data.Parser
{
    public static class XmlParser
    {
        public static void Serialize(Type dataType, object data, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(dataType);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            TextWriter writer = new StreamWriter(filePath);

            serializer.Serialize(writer, data);
            writer.Close();
        }

        public static object Deserialize(Type dataType, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(dataType);
            if (!File.Exists(filePath))
            {
                throw new FileLoadException();
            }

            TextReader textReader = new StreamReader(filePath);
            
            object data = serializer.Deserialize(textReader);
            textReader.Close();

            return data;
        }
    }
}
