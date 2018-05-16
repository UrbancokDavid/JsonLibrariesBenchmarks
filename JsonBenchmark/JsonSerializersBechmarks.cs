using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;

using JsonBenchmark.TestDTOs;

using Newtonsoft.Json;

namespace JsonBenchmark
{
    public class JsonSerializersBechmarks
    {
        [ClrJob(true)]
        [RPlotExporter, RankColumn]
        [HtmlExporter]
        public class JsonSerializersBenchmarks : JsonBenchmarkBase
        {
            private Root _root;
        

            [GlobalSetup(Target = nameof(NewtonsoftJson_Serialize))]
            public void SetUp() => _root = JsonConvert.DeserializeObject<Root>(ChuckNorrisJsonSampleString);


            [Benchmark]
            public string NewtonsoftJson_Serialize() => JsonConvert.SerializeObject(_root);


            [GlobalCleanup]
            public void GlobalCleanup() => _root = null;
        }
    }
}
