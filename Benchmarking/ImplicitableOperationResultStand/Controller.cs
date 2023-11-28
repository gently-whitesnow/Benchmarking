using BenchmarkDotNet.Attributes;
using Benchmarking.ImplicitableOperationResultStand.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Benchmarking.ImplicitableOperationResultStand;

/// <summary>
/// Отличие от лоадсов - частичное использование OperationResult
/// OperationResult - структура
/// </summary>
[MemoryDiagnoser]
public class Controller
{
    private Manager _manager;

    [GlobalSetup]
    public void Setup()
    {
        _manager = new Manager(new Client());
    }

    /// <summary>
    /// Запрашиваем доступ, если он есть отправляем смс и возвращаем структуру
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public Task<IResult> SendSmsAsync()
    {
        return _manager.SendSmsAsync().AsResultAsync();
    }

    /// <summary>
    /// Запрашиваем счетчик и преобразуем его к новой модели
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public async Task<IActionResult> GetCounterAsync()
    {
        var result =  await _manager.GetCounterAsync();
        return new JsonResult(result);
    }
}