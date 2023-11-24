using ATI.Services.Common.Behaviors.OperationBuilder.Extensions;
using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Benchmarking.AsyncCoreOperationResultStand;

[MemoryDiagnoser]
public class AsyncCoreTestedController
{
    private AsyncCoreTestedManager _coreTestedManager;

    [GlobalSetup]
    public void Setup()
    {
        _coreTestedManager = new AsyncCoreTestedManager(new AsyncCoreTestedClient());
    }

    /// <summary>
    /// Запрашиваем доступ, если он есть отправляем смс и возвращаем структуру
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public Task<IActionResult> SendSmsAsync()
    {
        return _coreTestedManager.SendSmsAsync().AsActionResultAsync();
    }

    /// <summary>
    /// Запрашиваем счетчик и преобразуем его к новой модели
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public Task<IActionResult> GetCounterAsync()
    {
        return _coreTestedManager.GetCounterAsync().AsActionResultAsync();
    }
}