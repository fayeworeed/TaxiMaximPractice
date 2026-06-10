using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using TaxiPractice.Core;

BenchmarkRunner.Run<SearchBenchmark>();

public class SearchBenchmark
{
    private List<Driver> drivers = null!;

    private readonly INearestDriverSearch linq =
        new LinqSearch();

    private readonly INearestDriverSearch manual =
        new ManualSearch();

    private readonly INearestDriverSearch partial =
        new PartialSearch();

    [GlobalSetup]
    public void Setup()
    {
        drivers = DriverGenerator.Generate(
            10000,
            1000,
            1000);
    }

    [Benchmark]
    public void Linq()
    {
        linq.FindNearestDrivers(
            drivers,
            500,
            500,
            5);
    }

    [Benchmark]
    public void Manual()
    {
        manual.FindNearestDrivers(
            drivers,
            500,
            500,
            5);
    }

    [Benchmark]
    public void Partial()
    {
        partial.FindNearestDrivers(
            drivers,
            500,
            500,
            5);
    }
}