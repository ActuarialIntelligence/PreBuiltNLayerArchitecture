
using System;
using System.Diagnostics;

namespace APIConsumerTestApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Python311\python.exe";
            var script = @"C:\Users\rajah\OneDrive\Documents\Projects\AI\Base\src\ActuarialIntelligence.Infrastructure.PythonScripts\Recommendation.py";
            psi.Arguments = $"\"{script}\"";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            var errors = "";
            var results = "";
            using (var process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }

            // 5) Display output
            Console.WriteLine("ERRORS:");
            Console.WriteLine(errors);
            Console.WriteLine();
            Console.WriteLine("Results:");
            Console.WriteLine(results);


        }

    }
}
