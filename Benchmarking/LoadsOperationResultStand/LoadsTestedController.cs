using BenchmarkDotNet.Attributes;
using Benchmarking.LoadsOperationResultStand.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Benchmarking.LoadsOperationResultStand;

[MemoryDiagnoser]
public class LoadsTestedController
{
    private LoadsTestedManager _loadsTestedManager;
    
    [GlobalSetup]
    public void Setup()
    {
        _loadsTestedManager = new LoadsTestedManager(new LoadsTestedClient());
    }

    /// <summary>
    /// Запрашиваем доступ, если он есть отправляем смс и возвращаем структуру
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public IActionResult SendSms()
    {
        var sendOperation = _loadsTestedManager.SendSms();

        // упрощенное представление
        if (sendOperation.IsNotSuccess)
        {
            if (sendOperation.Error is LoadsBadRequestError error)
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
    public IActionResult GetCounter()
    {
        var counterOperation = _loadsTestedManager.GetCounter();

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