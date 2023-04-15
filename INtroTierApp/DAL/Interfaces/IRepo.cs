using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<TYPE,ID,RET>
    {
        List<TYPE> Get();
        TYPE Get(ID id);
        RET Insert(TYPE obj);
        RET Update(TYPE obj);
        bool Delete(ID id);

        

    }
}
