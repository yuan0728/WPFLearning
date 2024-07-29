using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.BindingLesson.Example
{
    public class DataSourceA
    {
        public string Name { get; set; } = "Hello";
    }

    public class DataSourceB
    {
        public int Value { get; set; } = 100;
    }

    public class DataSource
    {
        public DataSourceA A { get; set; } = new DataSourceA();
        public DataSourceB B { get; set; } = new DataSourceB();
    }
}
