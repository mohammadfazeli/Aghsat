using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aghsat.ServiceLayer
{

    public enum AddStatus
    {
        Succeeded,
        Fail,
        Error,
        Exist

    }

    public enum DeleteStatus
    {
        Succeeded,
        Fail,
        Error,
        NotExist,

    }

    public enum updateStatus
    {
        Succeeded,
        Fail,
        Error,
        Exist,
        NotExist

    }
}
