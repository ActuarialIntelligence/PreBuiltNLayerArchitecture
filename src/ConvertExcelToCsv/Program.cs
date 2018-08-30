using AML.IOC;

namespace ConvertExcelToCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            DependencyResolution.ConstructContainer();
            var reader =  DependencyResolution.GetDJExcelFileReader();
            var result = reader.GetData();
            var serializer = DependencyResolution.GetFICOSerializer();
            var serializedResult = serializer.Serialize(result);
            var writer = DependencyResolution.GetFICOFileWriter(@"C:\Users\jyp1510\Documents\TestData\TestOutput.csv",
                "INSTITUTE|"+
                "CUSTNO|"+
                "FIRST_NAME|"+
                "LASTNAME_COMPANYNAME|"+
                "STREET|"+
                "ZIP|"+
                "TOWN|"+
                "H_COUNTRY|"+
                "CUSY|"+
                "FK_CSMNO|"+
                "PROFESSION|"+
                "BRANCH|"+
                "BIRTHDATE|"+
                "CUSTCONTACT|"+
                "EXEMPTIONFLAG|"+
                "EXEMPTIONAMOUNT|"+
                "ASYLSYN|"+
                "SALARY|"+
                "SALARYDATE|"+
                "NAT_COUNTRY|"+
                "TOT_WEALTH|"+
                "CUST_TYPE|"+
                "CUST_FLAG_01|"+
                "PASS_NO|"+
                "BIRTH_COUNTRY|"+
                "BIRTH_PLACE|"+
                "BORROWEYN|"+
                "DIRECT_DEBITYN|"+
                "GENDER|"+
                "RISK_CLASS");
            writer.Write(serializedResult);
        }
    }
}
