using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.MvvmLightLesson.DataAccess
{
    public interface IDataAccess
    {
        void Connect(string config);
        DataTable Red(string config);
    }
}
