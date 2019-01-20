using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigProvider;
using Logging;
using RoadStatusApi.Interface;
using RoadStatusShared.Model;
using RoadStatusShared.Service.Builder;

namespace RoadStatusShared.Service
{
    /// <summary>
    /// Service to provide functionality to call third-party APIs to get Road data and transform
    /// returned data into messages suitable for the application front-end
    /// </summary>
    public class RoadStatusService
    {
        private ILogger _logger;
        private IRoadStatusApi _roadStatusApi;

        public RoadStatusService(ILogger logger, IRoadStatusApi roadStatusApi)
        {
            _logger = logger;
            _roadStatusApi = roadStatusApi;
        }

        public async Task<RoadStatusResponse> GetRoadStatusAsync(string roadId)
        {
            _logger.LogInfo($"Calling Road Status Service for road Id: {roadId}");

            var roadStatusResponse = new RoadStatusResponse {ApplicationReturnCode = 0, InfoMessages = new List<string>()};
            var builders = RoadStatusBuilderCreator.CreateBuilders();
            var roadStatus = await _roadStatusApi.GetRoadStatusAsync(roadId);

            var builtMessages = builders.Select(b => b.GetMessage(roadStatus)).Where(m => m != null).ToList();

            foreach (var message in builtMessages)
            {
                if (!message.IsError)
                {
                    roadStatusResponse.InfoMessages.Add(message.Message);
                }
                else
                {
                    roadStatusResponse.InfoMessages.Add(message.Message);
                    roadStatusResponse.ApplicationReturnCode = 1;
                    return roadStatusResponse;
                }
            }

            return roadStatusResponse;
        }
    }
}
