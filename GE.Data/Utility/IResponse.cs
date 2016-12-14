using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GE.Data.Utility
{
    public interface IResponse<out T>
    {
        T Data { get; }

        bool Successful { get; }

        string Message { get; }

    }

    public enum ResponseStatus
    {
        Success, 
    }
}
