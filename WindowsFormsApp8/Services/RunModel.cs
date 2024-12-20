using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8.Services
{
    public class RunModel
    {
        public string askRunModel(string message)
        {
            string pythonScript = @"M:\Projects\SWEP\ChatBot\runmod.py"; // Path to your Python script
            string pythonExePath = @"C:\Python312\python.exe"; // Path to Python executable
            string argument = message;

            // Ensure the current directory is set to where the Python script and files are located
            string workingDirectory = Path.GetDirectoryName(pythonScript);  // Get the directory of the Python script
            Environment.CurrentDirectory = workingDirectory;

            // Start the Python script as a new process
            ProcessStartInfo start = new ProcessStartInfo
            {
                FileName = pythonExePath,
                Arguments = $"{pythonScript} {argument}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,  // Redirect error output for debugging
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = workingDirectory // Set the working directory for the process
            };

            using (Process process = Process.Start(start))
            {
                // Capture the standard output and standard error for debugging
                string result = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();
                //Console.WriteLine($"Python script output: {result}");
                //Console.WriteLine($"Python script errors: {errors}");
                process.WaitForExit();
            }

            // Wait for the Python script to finish and write to the response file

            string responseFilePath = @"M:\Projects\SWEP\ChatBot\response.txt"; // The file where Python script writes the response

            // Check if the response file exists and read it
            if (File.Exists(responseFilePath))
            {
                string result = File.ReadAllText(responseFilePath);
                Console.WriteLine(result);
                return result;
            }
            else
            {
                Console.WriteLine("Error: response.txt not found.");
            }
            return "";
        }
    }
}
