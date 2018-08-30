﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKF.Domain
{
    public class DJListRow
    {
        public DJListRow(List<string> Row, string ExcelSheetName, int ColumnCount)
        {
            this.Row = Row;
            this.ExcelSheetName = ExcelSheetName;
            this.ColumnCount = ColumnCount;
        }
        public List<string> Row { get; private set; }
        public string ExcelSheetName { get; private set; }
        public int ColumnCount { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">Starts at 0</param>
        /// <returns></returns>
        public string GetColValueAtIndex(int index)
        {
            var result = "";
            if(Row.Count()<=index)
            {
                result = Row[index];
            }
            return result;
        }

        public string GetAllRowsDelimited(char delimiter)
        {
            var result = "";
            foreach(var rowItem in Row)
            {
                result += rowItem + delimiter.ToString();
            }
            var length = result.Length;
            result = result.Substring(0, length - 1);
            return result;
        }

    }
}
