using System.Runtime.CompilerServices;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmarking;

[MemoryDiagnoser]
public class StringsTest
{
    [Params(10, 100, 1_000, 10_000)] public int N;

    [Benchmark]
    public string WithStringBuilder()
    {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < N; i++)
        {
            stringBuilder.Append(i);
            stringBuilder.Append(" ");
        }

        return stringBuilder.ToString();
    }

    [Benchmark]
    public string WithConcatenation()
    {
        string result = "";
        for (int i = 0; i < N; i++)
        {
            result = result + i + " ";
        }

        return result;
    }

    [Benchmark]
    public string WithInterpolation()
    {
        string result = "";
        for (int i = 0; i < N; i++)
        {
            result = $"{result}{i} ";
        }

        return result;
    }
}