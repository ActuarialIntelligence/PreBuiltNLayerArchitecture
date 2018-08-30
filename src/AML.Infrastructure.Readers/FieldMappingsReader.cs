using SKF.Infrastructure.Readers.Interfaces;
using System.Configuration;

namespace SKF.Infrastructure.Readers
{
    public class FieldMappingsReader : IKeyParametricDataReader<string>
    {
        /// <summary>
        /// Constructor Inject Connection objects into Reader. 
        /// </summary>
        public FieldMappingsReader()
        {

        }

        public string GetData(string keyValue)
        {
            var temp = ConfigurationManager.AppSettings[keyValue] == null ? ""
                : ConfigurationManager.AppSettings[keyValue].ToString();
            return temp;
        }
    }
}
