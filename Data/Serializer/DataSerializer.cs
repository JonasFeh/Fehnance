using Common;
using Data.Parser;

namespace Data.Serializer
{
    public class DataSerializer
    {
        public string FilePath { get; set; } = Constants.Data.DefaultPath;

        public bool Load<T>(string fileName, out T data) where T : class
        {
            var result = XmlParser.Deserialize(typeof(T), fileName, out var rawData);

            if (rawData is T)
            {
                data = (T)rawData;
                return result;
            }
            try
            {
                data = (T)Convert.ChangeType(rawData, typeof(T));
            }
            catch (InvalidCastException)
            {
                data = default;
                return false;
            }

            return result;
        }

        public void Save<T>(object data, string fileName)
        {
            XmlParser.Serialize(typeof(T), data, fileName);
        }
    }
}
