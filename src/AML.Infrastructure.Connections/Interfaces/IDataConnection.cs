using System.Collections.Generic;

namespace SKF.Infrastructure.Connections.Interfaces
{
    public interface IDataReadConnection<T>
    {
        T LoadData();
    }

    public interface IDataWriteConnection<T>
    {
        void WriteData(IList<T> values);
    }
}
