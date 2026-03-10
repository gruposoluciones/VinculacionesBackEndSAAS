using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vinculaciones.Api.common;

namespace Vinculaciones.Api.extensions;

public static class ModelStateExtensions
{
    public static List<ErrorField> ToErrorList(this ModelStateDictionary modelState)
    {
        return modelState
            .Where(x => x.Value?.Errors.Count > 0)
            .Select(x => new ErrorField
            {
                Field = x.Key,
                Message = x.Value!.Errors.First().ErrorMessage
            })
            .ToList();
    }
}
