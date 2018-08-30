using SKF.Domain;
using SKF.Infrastructure.Readers.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKF.Infrastructure.Readers
{
    public class DJExcelFileReader: IDataReader<IList<DJListRow>>
    {
        public DJExcelFileReader()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<DJListRow> GetData()
        {
            var sourceFile = ConfigurationManager.AppSettings["DJListSourceFile"];
            var worksheetName = ConfigurationManager.AppSettings["DJListWorksheetName"];


            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sourceFile + ";Extended Properties=Excel 12.0;"; // The connection string should be populated via another domain object that makes use of config manager.

            var conn = new OleDbConnection(strConn);
            conn.Open();
            var cmd = new OleDbCommand("SELECT * FROM [" + worksheetName + "$]", conn);
            cmd.CommandType = CommandType.Text;
            var reader = cmd.ExecuteReader();

            List<DJListRow> djList = PopulateDJListObjectWithListValues(reader, worksheetName);
            conn.Close();
            return djList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static List<DJListRow> PopulateDJListObjectWithListValues(OleDbDataReader reader,string worksheetName)
        {
            var colCount = reader.FieldCount;
            var djList = new List<DJListRow>();

            while (reader.Read())
            {
                var row = new List<string>();
                var cnt = 0;
                while (cnt < colCount)
                {
                    var temp = reader[cnt].ToString();
                    
                    row.Add(temp);
                    cnt++;
                }
                var column = new DJListRow(row, worksheetName, row.Count());
                djList.Add(column);
            }

            return djList;
        }
    }
}
