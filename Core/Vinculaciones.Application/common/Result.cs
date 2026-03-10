using System;
using Vinculaciones.Application.common;

namespace Vinculaciones.Api.common;

public class Result<T> where T : class
{
    public bool Success { get; private set; }
    public T? Value { get; private set; } = null!;
    public string? Error { get; private set; }
    public ResultCode ResultCode { get; private set; }

    public static Result<T> Ok(T value)
    {
        return new()
        {
            Success = true,
            Value = value,
            Error = null,
            ResultCode = ResultCode.Ok,
        };
    }

    public static Result<T> Fail(string error, ResultCode resultCode = ResultCode.BadRequest)
    {
        return new()
        {
            Success = false,
            Value = null,
            Error = error,
            ResultCode = resultCode
        };
    }
}
