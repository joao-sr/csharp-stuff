using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Instrumenting
{
    class Program
    {
        static void Main(string[] args)
        {
            // write to a text filein the project folder
            Trace.Listeners.Add(new TextWriterTraceListener(File.CreateText("log.txt")));

            // text writter is buffered, so this option calls
            // Flush() on all listners after writing
            Trace.AutoFlush = true;

            Debug.WriteLine("Debug says, I am watching");
            Trace.WriteLine("Trace says, I am watching");

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange:true);

            IConfigurationRoot configuration = builder.Build();

            var ts = new TraceSwitch(
                displayName: "PackSwitch",
                description: "This switch is set via JSON config."
            );

            configuration.GetSection("PackSwitch").Bind(ts);

            Trace.WriteLineIf(ts.TraceError, "Trace Error");
            Trace.WriteLineIf(ts.TraceWarning, "Trace warning");
            Trace.WriteLineIf(ts.TraceInfo, "Trace information");
            Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose");
        }
    }
}