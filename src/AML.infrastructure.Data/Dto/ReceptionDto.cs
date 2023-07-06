using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AML.infrastructure.Data.Dto
{
    public class ReceptionDto
    {
        public int id { get; set; }
        public string TEL_NO { get; set; }
        public string EMAIL { get; set; }
        public string HOSP_NAME { get; set; }
        public int? HospitalId { get; set; }

    }
}
