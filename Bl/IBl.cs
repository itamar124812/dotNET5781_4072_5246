using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi.DO;
using DalApi;
using Bl.BO;

namespace Bl
{
     public interface IBl
    {
        #region LineBus
         IEnumerable<LineBus> GetAllLines();
         LineBus GetLineBus();

        #endregion
    }
}
