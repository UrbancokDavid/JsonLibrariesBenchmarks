using System.IO;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;

using JsonBenchmark.TestDTOs;

using Newtonsoft.Json;

using Json;

namespace JsonBenchmark
{
    [ClrJob(true)]
    [RPlotExporter, RankColumn]
    [HtmlExporter]
    public class JsonDeserializersBenchmarks : JsonBenchmarkBase
    {
        [Benchmark]
        public Root NewtonsoftJson_Deserialize()
        {
            return JsonConvert.DeserializeObject<Root>(FirstChuckNorrisJsonSampleString);
        }


        [Benchmark]
        public Root NewtonsoftJson_Deserialize_Optimized()
        {
            Root root;

            using (var streamReader = new StreamReader(FirstJsonSampleString))
            using (JsonReader jsonReader = new JsonTextReader(streamReader))
            {
                var serializer = new JsonSerializer();

                root = serializer.Deserialize<Root>(jsonReader);
            }

            return root;
        }
    
    
        [Benchmark]
        public Root Json_Deserialize() => JsonParser.Deserialize<Root>(FirstJsonSampleString);


        [Benchmark]
        public Root NewtonsoftJson_Deserialize_SecondJson() => JsonConvert.DeserializeObject<Root>(SecondJsonSampleString);
    }
}
