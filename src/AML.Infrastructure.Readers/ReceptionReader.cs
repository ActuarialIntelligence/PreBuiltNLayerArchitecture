using SKF.Infrastructure.Readers.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AML.Infrastructure.Data.EF;
using AML.infrastructure.Data.Dto;
using SKF.Infrastructure.Connections.Interfaces;

namespace AML.Infrastructure.Readers
{
    public class ReceptionReader : IDataReader<IList<ReceptionDto>>
    {
        public ReceptionReader() { }
        private IDataReadConnection<IList<RECEPTION>> receptionConnection;
        public ReceptionReader(IDataReadConnection<IList<RECEPTION>> receptionConnection) 
        { 
            this.receptionConnection = receptionConnection;
        }
        public IList<ReceptionDto> GetData()
        {
            var receptionData = receptionConnection.LoadData();
            var results = new List<ReceptionDto>();
            foreach(var recItem in receptionData)
            {
                var obj = new ReceptionDto() { EMAIL= recItem.EMAIL, HospitalId = recItem.HospitalId, HOSP_NAME = recItem.HOSP_NAME, id = recItem.id };
                results.Add(obj);
            }

            return results;// throw new NotImplementedException();
        }
    }
}
