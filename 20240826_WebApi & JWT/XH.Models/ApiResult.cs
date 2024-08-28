using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Models
{
    public class ApiResult<T>
    {
        public string? Message { get; set; }
        public bool Success { get; set; }
        public T Value { get; set; }
    }
}
