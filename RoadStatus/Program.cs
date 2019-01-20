using System;
using System.Linq;
using System.Threading.Tasks;
using ConfigProvider;
using Logging;
using RoadStatusApi.TflApi;
using RoadStatusShared.Service;

namespace RoadStatus
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a Road Id");
                Environment.ExitCode = -1;
            }
            else
            {
                var logger = new StubLogger();

                try
                {
                    // If I were to carry on building this out I would use a DI container like
                    // StructureMap to manage dependencies
                    var configProvider = new JsonFileConfigurationProvider(logger);
                    var api = new TflRoadStatusApi(configProvider, logger);

                    var service = new RoadStatusService(logger, api);
                    var result = await service.GetRoadStatusAsync(args[0]);

                    result.InfoMessages.ForEach(m => Console.WriteLine(m));
                    Environment.ExitCode = result.ApplicationReturnCode;
                }
                catch (Exception e)
                {
                    Environment.ExitCode = -1;
                    logger.LogException(e);
                    Console.WriteLine($"Unexpected Error: {e.Message}");
                }
            }
        }
    }
}
