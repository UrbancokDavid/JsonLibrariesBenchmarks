using System.IO;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;

using JsonBenchmark.TestDTOs;

using Newtonsoft.Json;

using Manatee.Json;

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
            return JsonConvert.DeserializeObject<Root>(FirstJsonSampleString);
        }


        [Benchmark]
        public Root NewtonsoftJson_Deserialize_Optimized()
        {
            Root root;

            using (var streamReader = new StreamReader(FirstChuckNorrisJsonSamplePath))
            using (JsonReader jsonReader = new JsonTextReader(streamReader))
            {
                var serializer = new JsonSerializer();

                root = serializer.Deserialize<Root>(jsonReader);
            }

            return root;
        }


        [Benchmark]
        public Root NewtonsoftJson_Deserialize_SecondJson()
        {
            return JsonConvert.DeserializeObject<Root>(SecondJsonSampleString);
        } 


        [Benchmark]
        public Root Manatee_Deserialize()
        {
            var jsonSerializer = new Manatee.Json.Serialization.JsonSerializer();
            var jsonValue = JsonValue.Parse(FirstJsonSampleString);

            return jsonSerializer.Deserialize<Root>(jsonValue);
        }


        [Benchmark]
        public Root ServiceStack_Deserialize()
        {
            return ServiceStack.Text.JsonSerializer.DeserializeFromString<Root>(FirstJsonSampleString);
        }


        [Benchmark]
        public Root ServiceStack_Deserialize_TextReader()
        {
            Root result;

            using (var streamReader = new StreamReader(FirstChuckNorrisJsonSamplePath))
            {
                result = ServiceStack.Text.JsonSerializer.DeserializeFromReader<Root>(streamReader);
            }

            return result;
        }
    }
}
