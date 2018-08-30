using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using SKF.Domain;
using SKF.Infrastructure.Writers.Interfaces;
using SKF.infrastructure.Data.Dto;
using SKF.Infrastructure.Connections.Interfaces;

namespace SKF.Infrastructure.Writers
{
    public class FICOFileWriter : IDataWrite<IList<IList<FieldNameInputValuePair>>>
    {
        private readonly IDataWriteConnection<FICOFieldsDto> connection;
        public FICOFileWriter(IDataWriteConnection<FICOFieldsDto> connection)
        {
            this.connection = connection;
        }
        public void Write(IList<IList<FieldNameInputValuePair>> values)
        {
            //var obj = new FICOFields();
            //Type type = obj.GetType();
            //PropertyInfo pi = type.GetProperty("FIRST_NAME");
            //pi.SetValue(obj, "Rajmeister", null);
            var list = new List<FICOFieldsDto>();
            foreach (var item in values)
            {
                var obj = new FICOFieldsDto();
                foreach (FieldNameInputValuePair pair in item)
                {
                    Type type = obj.GetType();
                    PropertyInfo pi = type.GetProperty(pair.FieldName);
                    if (pi != null)
                    {
                        pi.SetValue(obj, pair.FieldValue, null);
                    }
                }
                list.Add(obj);
            }
            connection.WriteData(list);
        }
    }
}
