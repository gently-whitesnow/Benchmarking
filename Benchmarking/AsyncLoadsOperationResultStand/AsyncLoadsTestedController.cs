using BenchmarkDotNet.Attributes;
using Benchmarking.AsyncLoadsOperationResultStand.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Benchmarking.AsyncLoadsOperationResultStand;

[MemoryDiagnoser]
public class AsyncLoadsTestedController
{
    private AsyncLoadsTestedManager _loadsTestedManager;
    
    [GlobalSetup]
    public void Setup()
    {
        _loadsTestedManager = new AsyncLoadsTestedManager(new AsyncLoadsTestedClient());
    }

    /// <summary>
    /// Запрашиваем доступ, если он есть отправляем смс и возвращаем структуру
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public async Task<IActionResult> SendSms()
    {
        var sendOperation = await _loadsTestedManager.SendSms();

        // упрощенное представление
        if (sendOperation.IsNotSuccess)
        {
            if (sendOperation.Error is AsyncLoadsBadRequestError error)
                return new ObjectResult(error)
                {
                    StatusCode = 400
                };
        }

        return new JsonResult(sendOperation.Result);
    }


    /// <summary>
    /// Запрашиваем счетчик и преобразуем его к новой модели
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public async Task<IActionResult> GetCounter()
    {
        var counterOperation = await _loadsTestedManager.GetCounter();

        // упрощенное представление
        if (counterOperation.IsNotSuccess)
        {
            return new JsonResult("internal_server_error")
            {
                StatusCode = 500
            };
        }

        return new JsonResult(counterOperation.Result);
    }
}