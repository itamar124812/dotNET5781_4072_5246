using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
namespace Bl
{
    class BlImp:IBl
    {
        IDal Dl = DalFactory.GetDL();

    }
}
