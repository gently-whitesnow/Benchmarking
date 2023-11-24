using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Benchmarking.TrucksOperationResultStand.Entities;

public static class TruckOperationResultExtensions
{
    public static IActionResult AsActionResult<T>(this TruckOperationResult<T> operation)
    {
        if (operation.IsSuccess)
            return new JsonResult(operation.Value);

        return new JsonResult(operation.Error)
        {
            StatusCode = (int)(operation.Error switch 
            {
                TruckBadRequestError => HttpStatusCode.BadRequest,
                _ => throw new NotImplementedException("Данный тип ошибки не определен")
            })
        };
    }
}