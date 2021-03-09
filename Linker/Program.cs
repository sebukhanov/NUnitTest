using System.Threading.Tasks;
using System;

namespace Linker
{
    class Program
    {
        public static readonly string Domain = "https://demo.testit.software/";
        public static readonly string PrivateToken = "OGl6MnVTNzNXQXEyQm9RTUNo";
        public static readonly Guid ProjectId = new Guid("2fd05113-d410-4ea0-a1af-07e7d91336cb");

        static async Task Main()
        {
            ApiClient client = new ApiClient(Domain, PrivateToken, ProjectId);
            await AddAutoTestToTestCaseAsync(client);
            Console.WriteLine("Open https://demo.testit.software/projects/66/autotests to view new autotests.");
        }

        private static async Task AddAutoTestToTestCaseAsync(ApiClient client)
        {
            await client.CreateAndAddAutoTestToTestCase(1, "Search");
        }
    }
}
