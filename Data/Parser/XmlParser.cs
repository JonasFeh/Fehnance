using Common;
using System.Xml.Serialization;

namespace Data.Parser
{
    public static class XmlParser
    {
        private static string FileExtension = ".xml";

        public static void Serialize(Type dataType, object data, string fileName)
        {
            var aCompleteFilePath = Constants.Data.DefaultPath + fileName + FileExtension;

            Directory.CreateDirectory(Constants.Data.DefaultPath);

            XmlSerializer serializer = new XmlSerializer(dataType);
            if (File.Exists(aCompleteFilePath))
            {
                File.Delete(aCompleteFilePath);
            }

            TextWriter writer = new StreamWriter(aCompleteFilePath);

            serializer.Serialize(writer, data);
            writer.Close();
        }

        public static bool Deserialize(Type dataType, string fileName, out object data)
        {
            var aCompleteFilePath = Constants.Data.DefaultPath + fileName + FileExtension;

            XmlSerializer serializer = new XmlSerializer(dataType);
            if (!File.Exists(aCompleteFilePath))
            {
                data = new object();
                return false;
            }

            TextReader textReader = new StreamReader(aCompleteFilePath);
            try
            {
                data = serializer.Deserialize(textReader) ?? throw new NullReferenceException("Unable to deserialize the file.");
            }
            catch (Exception)
            {
                data = new object();
                return false;
            }

            textReader.Close();

            return true;
        }
    }
}
