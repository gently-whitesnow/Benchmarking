using BenchmarkDotNet.Attributes;
using Benchmarking.TrucksOperationResultStand.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Benchmarking.TrucksOperationResultStand;

/// <summary>
/// Отличие от лоадсов - частичное использование OperationResult
/// OperationResult - структура
/// </summary>
[MemoryDiagnoser]
public class TruckTestedController
{
    private TruckTestedManager _truckTestedManager;

    [GlobalSetup]
    public void Setup()
    {
        _truckTestedManager = new TruckTestedManager(new TruckTestedClient());
    }

    /// <summary>
    /// Запрашиваем доступ, если он есть отправляем смс и возвращаем структуру
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public IActionResult SendSms()
    {
        return _truckTestedManager.SendSms().AsActionResult();
    }

    /// <summary>
    /// Запрашиваем счетчик и преобразуем его к новой модели
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public IActionResult GetCounter()
    {
        return new JsonResult(_truckTestedManager.GetCounter());
    }
}