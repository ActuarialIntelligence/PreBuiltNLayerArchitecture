using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace SKF.infrastructure.Data.Dto
{
    [DelimitedRecord("|")]
    [IgnoreEmptyLines()]
    public class FICOFieldsDto
    {
        [FieldOrder(1)]
        public string INSTITUTE { get; set; }
        [FieldOrder(2)]
        public string CUSTNO { get; set; }
        [FieldOrder(3)]
        public string FIRST_NAME { get; set; }
        [FieldOrder(4)]
        public string LASTNAME_COMPANYNAME { get; set; }
        [FieldOrder(5)]
        public string STREET { get; set; }
        [FieldOrder(6)]
        public string ZIP { get; set; }
        [FieldOrder(7)]
        public string TOWN { get; set; }
        [FieldOrder(8)]
        public string H_COUNTRY { get; set; }
        [FieldOrder(9)]
        public string CUSY { get; set; }
        [FieldOrder(10)]
        public string FK_CSMNO { get; set; }
        [FieldOrder(11)]
        public string PROFESSION { get; set; }
        [FieldOrder(12)]
        public string BRANCH { get; set; }
        [FieldOrder(13)]
        public string BIRTHDATE { get; set; }
        [FieldOrder(14)]
        public string CUSTCONTACT { get; set; }
        [FieldOrder(15)]
        public string EXEMPTIONFLAG { get; set; }
        [FieldOrder(16)]
        public string EXEMPTIONAMOUNT { get; set; }
        [FieldOrder(17)]
        public string ASYLSYN { get; set; }
        [FieldOrder(18)]
        public string SALARY { get; set; }
        [FieldOrder(19)]
        public string SALARYDATE { get; set; }
        [FieldOrder(20)]
        public string NAT_COUNTRY { get; set; }
        [FieldOrder(21)]
        public string TOT_WEALTH { get; set; }
        [FieldOrder(22)]
        public string CUST_TYPE { get; set; }
        [FieldOrder(23)]
        public string CUST_FLAG_01 { get; set; }
        [FieldOrder(24)]
        public string PASS_NO { get; set; }
        [FieldOrder(25)]
        public string BIRTH_COUNTRY { get; set; }
        [FieldOrder(26)]
        public string BIRTH_PLACE { get; set; }
        [FieldOrder(27)]
        public string BORROWEYN { get; set; }
        [FieldOrder(28)]
        public string DIRECT_DEBITYN { get; set; }
        [FieldOrder(29)]
        public string GENDER { get; set; }
        [FieldOrder(30)]
        public string RISK_CLASS { get; set; }
    }
}
