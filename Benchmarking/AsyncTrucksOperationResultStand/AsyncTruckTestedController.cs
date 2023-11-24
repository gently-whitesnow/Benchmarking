using BenchmarkDotNet.Attributes;
using Benchmarking.AsyncTrucksOperationResultStand.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Benchmarking.AsyncTrucksOperationResultStand;

/// <summary>
/// Отличие от лоадсов - частичное использование OperationResult
/// OperationResult - структура
/// </summary>
[MemoryDiagnoser]
public class AsyncTruckTestedController
{
    private AsyncTruckTestedManager _truckTestedManager;

    [GlobalSetup]
    public void Setup()
    {
        _truckTestedManager = new AsyncTruckTestedManager(new AsyncTruckTestedClient());
    }

    /// <summary>
    /// Запрашиваем доступ, если он есть отправляем смс и возвращаем структуру
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public Task<IActionResult> SendSmsAsync()
    {
        return _truckTestedManager.SendSmsAsync().AsActionResultAsync();
    }

    /// <summary>
    /// Запрашиваем счетчик и преобразуем его к новой модели
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public async Task<IActionResult> GetCounterAsync()
    {
        var result =  await _truckTestedManager.GetCounterAsync();
        return new JsonResult(result);
    }
}