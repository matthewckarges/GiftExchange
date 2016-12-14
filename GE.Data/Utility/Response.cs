using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GE.Data.Utility
{
    public class Response<T> : IResponse<T>
    {
        public T Data { get; internal set; }

        public bool Successful { get; internal set; }

        public string Message { get; internal set; }

        internal bool HasPermission
    }
}
