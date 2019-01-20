using System;
using System.Threading.Tasks;
using ConfigProvider;
using Logging;
using RoadStatusApi.TflApi;

namespace RoadStatus
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ILogger logger = new StubLogger();
            IConfigurationProvider provider = new JsonFileConfigurationProvider(logger);
            var api = new TflRoadStatusApi(provider);
            var abc = await api.GetRoadStatusAsync("A2");
        }
    }
}
