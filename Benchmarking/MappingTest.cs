using BenchmarkDotNet.Attributes;

namespace Benchmarking;

[MemoryDiagnoser]
public class MappingTest
{
    [Params(10, 20, 30, 40, 50, 60, 70, 80, 90, 100)]
    public int N;

    private List<SampleClass> _from;
    private List<SampleClass> _to;

    [GlobalSetup]
    public void Setup()
    {
        _from = new List<SampleClass>(N);
        _to = new List<SampleClass>(N);
        Random rnd = new Random();
        for (int i = 0; i < N; i++)
        {
            _from.Add(new SampleClass
            {
                Id = i,
                Name = i.ToString()
            });
            _to.Add(new SampleClass
            {
                Id = rnd.Next(0,9),
            });
        }
    }
    
    [Benchmark]
    public List<SampleClass> DoubleFor()
    {
        foreach (var from in _from)
        {
            foreach (var to in _to)
            {
                if (from.Id == to.Id)
                    to.Name = from.Name;
            }
        }

        return _to;
    }

    [Benchmark]
    public List<SampleClass> Dictionary()
    {
        var dict = _from.ToDictionary(v => v.Id);
        
        foreach (var to in _to)
        {
            to.Name = dict[to.Id].Name;
        }
        
        return _to;
    }
}

public class SampleClass
{
    public int Id { get; set; }
    public string Name { get; set; }
}