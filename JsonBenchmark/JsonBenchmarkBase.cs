using System;
using System.IO;

namespace JsonBenchmark
{
    public abstract class JsonBenchmarkBase
    {
        private const string TestFilesFolder = "TestFiles";

        protected string FirstJsonSampleString;
        protected string SecondJsonSampleString;

        protected string FirstChuckNorrisJsonSampleString = Path.Combine(AppContext.BaseDirectory, TestFilesFolder, "chucknorris.json");
        protected string SecondChuckNorrisJsonSampleString = Path.Combine(AppContext.BaseDirectory, TestFilesFolder, "chucknorris.json");

        protected JsonBenchmarkBase()
        {
            FirstJsonSampleString = File.ReadAllText(FirstChuckNorrisJsonSampleString);
            SecondJsonSampleString = File.ReadAllText(SecondChuckNorrisJsonSampleString);
        }
    }
}
