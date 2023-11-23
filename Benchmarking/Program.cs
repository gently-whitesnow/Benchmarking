// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using Benchmarking;

BenchmarkRunner.Run<MappingTest>();
Console.WriteLine("Hello, World!");