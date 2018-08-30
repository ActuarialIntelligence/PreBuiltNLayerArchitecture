using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKF.Serialization.Interfaces
{
    public interface ISerialize<U,P>
    {
        P Serialize(U inputObject);
    }
}
