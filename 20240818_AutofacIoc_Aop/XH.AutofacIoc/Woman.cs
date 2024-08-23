using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.AutofacIoc
{
    public class Woman : IPerson
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void SayHello()
        {
            Console.WriteLine("Woman Say Hello");
        }
    }
}
