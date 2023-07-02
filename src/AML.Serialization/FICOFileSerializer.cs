using SKF.Domain;
using SKF.Infrastructure.Readers.Interfaces;
using SKF.Serialization.Interfaces;
using System.Collections.Generic;

namespace SKF.Serialization
{
    public class FICOFileSerializer : ISerialize<IList<DJListRow>, IList<IList<FieldNameInputValuePair>>>
    {
        private readonly IKeyParametricDataReader<string> reader;
        public FICOFileSerializer(IKeyParametricDataReader<string> reader)
        {
            this.reader = reader;
        }
        public IList<IList<FieldNameInputValuePair>> Serialize(IList<DJListRow> inputObject)
        {
            var serializedObject = new List<IList<FieldNameInputValuePair>>();
            foreach (var value in inputObject)
            {
                var pairList = new List<FieldNameInputValuePair>();
                var columnCount = value.ColumnCount;
                var sheetName = value.ExcelSheetName;
                for(int i=1;i<=columnCount;i++)
                {
                    var key = sheetName + "_" + i;
                    var fieldName = reader.GetData(key);
                    var pair = new FieldNameInputValuePair(fieldName, value.Row[i-1]);
                    pairList.Add(pair);
                }
                serializedObject.Add(pairList);
            }
            return serializedObject;
        }
    }
}
