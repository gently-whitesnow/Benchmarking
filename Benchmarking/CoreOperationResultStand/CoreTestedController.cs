using ATI.Services.Common.Behaviors.OperationBuilder.Extensions;
using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Benchmarking.CoreOperationResultStand;

[MemoryDiagnoser]
public class CoreTestedController
{
    private CoreTestedManager _coreTestedManager;

    [GlobalSetup]
    public void Setup()
    {
        _coreTestedManager = new CoreTestedManager(new CoreTestedClient());
    }

    /// <summary>
    /// Запрашиваем доступ, если он есть отправляем смс и возвращаем структуру
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public IActionResult SendSms()
    {
        return _coreTestedManager.SendSms().AsActionResult();
    }

    /// <summary>
    /// Запрашиваем счетчик и преобразуем его к новой модели
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public IActionResult GetCounter()
    {
        return _coreTestedManager.GetCounter().AsActionResult();
    }
}