using JenkinsNET;
using JenkinsNET.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTest
{
    class Jenkins
    {
        private readonly string jobName = "sleep";
        IDictionary<string, string> jobParameters = null;
        public void RunJenkinsJob()
        {
            var client = new JenkinsClient
            {
                BaseUrl = "http://localhost:8080",
                UserName = "admin",
                ApiToken = "1141f2f2bfdcc2ef3c20f1879fd3b2db52",
            };

            var runner = new JenkinsJobRunner(client);

            runner.StatusChanged += () => {
                switch (runner.Status)
                {
                    case JenkinsJobStatus.Queued:
                        Console.WriteLine("Job is Queued.");
                        break;
                    case JenkinsJobStatus.Building:
                        Console.WriteLine("Job is Running.");
                        break;
                    case JenkinsJobStatus.Complete:
                        Console.WriteLine("Job is Complete.");
                        break;
                }
            };

            Console.WriteLine($"Starting Job '{jobName}'...");

            var buildResult = (jobParameters?.Any() ?? false)
                ? runner.RunWithParameters(jobName, jobParameters)
                : runner.Run(jobName);

            if (!string.Equals(buildResult?.Result, "SUCCESS"))
                throw new ApplicationException($"Build #{buildResult?.Number} Failed!");

            Console.WriteLine($"Build #{buildResult?.Number} completed successfully.");
            Console.WriteLine($"Report: {buildResult?.Url}");
        }
        
    }
}
