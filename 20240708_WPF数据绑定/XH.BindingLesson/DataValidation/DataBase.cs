using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.BindingLesson.DataValidation
{
    public class DataBase : IDataErrorInfo
    {
        public string Error { get; set; }
        public string this[string columnName] => throw new NotImplementedException();
    }
}
