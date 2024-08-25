using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.DesignPattern.AdapterPattern
{
    // 数据访问接口
    public interface IHelper
    {
        void Add<T>();
        void Delete<T>();
        void Update<T>();
        void Query<T>();
    }
}
