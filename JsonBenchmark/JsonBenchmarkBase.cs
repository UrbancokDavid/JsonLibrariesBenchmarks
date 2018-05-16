using System;
using System.IO;

namespace JsonBenchmark
{
    public abstract class JsonBenchmarkBase
    {
        private const string TestFilesFolder = "TestFiles";

        protected string FirstJsonSampleString;
        protected string SecondJsonSampleString;

        protected string FirstChuckNorrisJsonSamplePath = Path.Combine(AppContext.BaseDirectory, TestFilesFolder, "chucknorris.json");
        protected string SecondChuckNorrisJsonSamplePath = Path.Combine(AppContext.BaseDirectory, TestFilesFolder, "chucknorris.json");

        protected JsonBenchmarkBase()
        {
            FirstJsonSampleString = File.ReadAllText(FirstChuckNorrisJsonSamplePath);
            SecondJsonSampleString = File.ReadAllText(SecondChuckNorrisJsonSamplePath);
        }
    }
}
