using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKF.Infrastructure.Readers.Interfaces
{
    public interface IDataReader<P>
    {
        P GetData();
    }

         public interface IKeyParametricDataReader<P>
        {
             P GetData(string keyValue);
        }

}
