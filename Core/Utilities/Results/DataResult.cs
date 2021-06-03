using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(T data,string message,bool success):this(success)
        {
            Data = data;
            Message = message;
        }
        public DataResult(T data, bool success) : this(success)
        {
            Data = data;
            
        }
        public DataResult(bool success)
        {
            Success = success;
        }
        public T Data { get; }

        public bool Success { get; }

        public string Message { get; }
    }
}
