using FileHelpers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SKF.Infrastructure.Connections.Interfaces;

namespace SKF.Infrastructure.Connections
{
    public class CsvDataReaderConnection<T> : IDataReadConnection<IList<T>> where T : class
    {
        private readonly FileHelperEngine<T> engine;
        private string path;
        public CsvDataReaderConnection(string path)
        {
            engine = new FileHelperEngine<T>();
            this.path = path;
        }

        public virtual IList<T> LoadData()
        {
            using (var fileStream = new FileStream(path
                , FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var streamReader = new StreamReader(fileStream))
            {
                return engine.ReadStream(streamReader).ToList();
            }
        }

    }
}
