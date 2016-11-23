using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.Application
{
    public class R<TData> : R
    {
        public TData Data { get; set; }

        public static R<TData> Success(TData data)
        {
            return new R<TData> { IsSuccess = true, Data = data };
        }

        public static new R<TData> Error(string msg)
        {
            return new R<TData> { IsSuccess = false, Msg = msg };
        }
    }

    public class R
    {
        public string Msg { get; set; }

        public bool IsSuccess { get; set; }

        public static R Success()
        {
            return new R { IsSuccess = true };
        }

        public static R Error(string msg)
        {
            return new R { IsSuccess = false, Msg = msg };
        }
    }
}
