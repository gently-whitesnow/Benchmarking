using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Benchmarking.AsyncTrucksOperationResultStand.Entities;

public static class AsyncTruckOperationResultExtensions
{
    public static async Task<IActionResult> AsActionResultAsync<T>(this Task<AsyncTruckOperationResult<T>> operationTask)
    {
        await operationTask;
        if (operationTask.Result.IsSuccess)
            return new JsonResult(operationTask.Result.Value);

        return new JsonResult(operationTask.Result.Error)
        {
            StatusCode = (int)(operationTask.Result.Error switch 
            {
                AsyncTruckBadRequestError => HttpStatusCode.BadRequest,
                _ => throw new NotImplementedException("Данный тип ошибки не определен")
            })
        };
    }
}