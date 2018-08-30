using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKF.Domain
{
    public class FieldNameInputValuePair
    {
        public FieldNameInputValuePair(string fieldName,string fieldValue)
        {
            FieldName = fieldName;
            FieldValue = fieldValue;
        }

        public string FieldName { get; private set; }
        public string FieldValue { get; private set; }
    }
}
