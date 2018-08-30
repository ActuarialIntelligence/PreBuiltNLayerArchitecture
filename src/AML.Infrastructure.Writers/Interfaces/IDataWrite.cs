using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKF.Infrastructure.Writers.Interfaces
{
    public interface IDataWrite<P>
    {
        void Write(P values);
    }
}
