using System.Net;
using Microsoft.AspNetCore.Http;

namespace Benchmarking.ImplicitableOperationResultStand.Entities;

public static class OperationExtensions
{
    public static async Task<IResult> AsResultAsync<TValue>(this Task<Operation<TValue>> operationTask)
    {
        await operationTask;
        
        if (operationTask.Result.IsSuccess)
            return Results.Json(operationTask.Result.Value);

        var code = (int)(operationTask.Result.Error switch
        {
            BadRequestError => HttpStatusCode.BadRequest,
            _ => throw new NotImplementedException("Данный тип ошибки не определен")
        });

        return Results.Json(operationTask.Result.Error, statusCode: code);
    }
}