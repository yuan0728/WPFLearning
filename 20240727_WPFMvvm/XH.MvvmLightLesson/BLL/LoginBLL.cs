using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.MvvmLightLesson.Base;
using XH.MvvmLightLesson.DataAccess;

namespace XH.MvvmLightLesson.BLL
{
    public class LoginBLL : ILoginBLL
    {
        public int LoginId { get; set; }
        public LoginBLL([Dependy("MySqlDA")]IDataAccess dataAccess) // MySql
        {
            
        }

        public void Login()
        {
            throw new NotImplementedException();
        }
    }
}
