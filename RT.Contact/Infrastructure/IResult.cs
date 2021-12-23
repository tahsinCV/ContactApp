using System;
using System.Collections.Generic;
using System.Text;

namespace RT.Contacts.ResultType
{
    public interface IResult<T> : IResult
    {
        T Data { get; set; }
    }

    public interface IResult
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
        ResultTypeEnum ResultType { get; set; }
    }
}
