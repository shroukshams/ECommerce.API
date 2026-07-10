using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Common
{
    public class Result//void
    {
        public bool IsSuccess { get; }
        public IReadOnlyList<Erorr> Erorrs { get;  }

        public Result(bool isSuccess, IReadOnlyList<Erorr> erorrs)
        {
            IsSuccess = isSuccess;
            this.Erorrs = erorrs;
        }

        public static Result Ok()
        => new Result(true, Array.Empty<Erorr>());
        public static Result Fail(Erorr erorr) => new Result(false,  new[] { erorr });
        public static Result Fail(IReadOnlyList<Erorr> erorrs) => new Result(false, erorrs);


    }
    public class Result<TValue> : Result
    {
        private readonly TValue _value;
        public TValue data =>IsSuccess ? _value : throw new InvalidOperationException("Cannot access the value of a failed result.");


        public Result(TValue value):base(true, Array.Empty<Erorr>())
        {
            _value = value;
        }
        public Result(Erorr erorr) : base(false, new[] { erorr })
        {
           _value = default;
        }


        public Result(IReadOnlyList<Erorr> erorrs) : base(false, erorrs)
        {
            this._value = default;
        }



        public static Result<TValue> Ok(TValue value)
        => new Result<TValue>(value);
        public static Result<TValue> Fail(Erorr erorr) => new Result<TValue>(erorr);
        public static Result<TValue> Fail(IReadOnlyList<Erorr> erorrs) => new Result<TValue>(erorrs);


    }
}    



