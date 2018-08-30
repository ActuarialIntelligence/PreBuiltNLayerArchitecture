using SKF.Infrastructure.Connections.Interfaces;
using FileHelpers;
using System.Collections.Generic;

namespace SKF.Infrastructure.Connections
{
    public class CsvDataWriterConnection<T> : IDataWriteConnection<T> where T : class
    {
        private readonly FileHelperEngine<T> engine;
        private string path;
        public CsvDataWriterConnection(string path, string headers)
        {
            engine = new FileHelperEngine<T>();
            engine.HeaderText = headers;
            this.path = path;
        }

        public virtual void WriteData(IList<T> values)
        {
            engine.WriteFile(path, values);
        }
    }
}
