using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GE.Data.Utility
{
    public class Response<T> : IResponse<T>
    {
        public T Data { get; internal set; }

        public ResponseStatus Status { get; internal set; }

        public string Message { get; internal set; }

        internal void NoAccess()
        {
            Data = default(T);
            Message = "User does not have permission to access this resource";
            Status = ResponseStatus.NoAccess;
        }

        internal void Error(Exception ex)
        {
            Data = default(T);
            Message = ex.Message ?? "There was an error accessing this resource";
            Status = ResponseStatus.Error;
        }  
    }
}
