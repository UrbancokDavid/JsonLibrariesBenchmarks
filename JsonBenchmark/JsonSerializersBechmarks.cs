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
        

            [GlobalSetup]
            public void SetUp() => _root = JsonConvert.DeserializeObject<Root>(FirstJsonSampleString);


            [Benchmark]
            public string NewtonsoftJson_Serialize() => JsonConvert.SerializeObject(_root);

            
            [Benchmark]
            public string Manatee_Serialize() => new Manatee.Json.Serialization.JsonSerializer().Serialize(_root).ToString();
        
        
            [Benchmark]
            public string ServiceStack_Serialize() => ServiceStack.Text.JsonSerializer.SerializeToString(_root);


            [GlobalCleanup]
            public void GlobalCleanup() => _root = null;
        }
    }
}
