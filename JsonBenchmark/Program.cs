using System;
using BenchmarkDotNet.Running;

namespace JsonBenchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<JsonDeserializersBenchmarks>();

            BenchmarkRunner.Run<JsonSerializersBechmarks>();

            //Console.ReadKey();
        }
    }
}
