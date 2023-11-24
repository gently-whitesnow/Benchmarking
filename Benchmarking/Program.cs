// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using Benchmarking.AsyncCoreOperationResultStand;
using Benchmarking.AsyncLoadsOperationResultStand;
using Benchmarking.AsyncTrucksOperationResultStand;
using Benchmarking.CoreOperationResultStand;
using Benchmarking.LoadsOperationResultStand;
using Benchmarking.TrucksOperationResultStand;

BenchmarkRunner.Run<AsyncCoreTestedController>();
// BenchmarkRunner.Run<AsyncLoadsTestedController>();
// BenchmarkRunner.Run<AsyncTruckTestedController>();
//
// BenchmarkRunner.Run<CoreTestedController>();
// BenchmarkRunner.Run<LoadsTestedController>();
// BenchmarkRunner.Run<TruckTestedController>();

Console.WriteLine("Hello, World!");