using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, message, true)
        {

        }
        public ErrorDataResult(T data) : base(data, true)
        {

        }
        public ErrorDataResult() : base(true)
        {

        }
    }
}
