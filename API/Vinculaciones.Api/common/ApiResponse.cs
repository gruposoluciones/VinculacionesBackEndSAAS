using System;

namespace Vinculaciones.Api.common;

public class ApiResponse<T, E>
    where T : class
    where E : class
{
    public int StatusCode { get; set; }
    public bool Success { get; set; }
    public E? Error { get; set; }
    public T? Data { get; set; }

    public ApiResponse(int statusCode, bool success, T? data = null, E? error = null)
    {
        StatusCode = statusCode;
        Success = success;
        Data = data;
        Error = error;
    }
}
