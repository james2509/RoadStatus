using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ConfigProvider;
using Logging;
using Newtonsoft.Json.Linq;
using RoadStatusApi.Exception;
using RoadStatusApi.Interface;
using RoadStatusApi.Model;

namespace RoadStatusApi.TflApi
{
    /// <summary>
    /// Implementation of Road Status to call the Tfl Api to get Road status data
    /// </summary>
    public class TflRoadStatusApi : IRoadStatusApi
    {
        private IConfigurationProvider _configProvider;
        private ILogger _logger;

        public TflRoadStatusApi(IConfigurationProvider configProvider, ILogger logger)
        {
            _configProvider = configProvider;
            _logger = logger;
        }

        public async Task<RoadStatus> GetRoadStatusAsync(string roadId)
        {
            _logger.LogInfo($"Calling API to get Road data for Road {roadId}");
            RoadStatus roadStatus;

            using (var tflClient = new HttpClient())
            {
                var endpointUrl = new Uri(_configProvider.GetConfiguration().GetRoadSummaryEndPoint(roadId));
                var response = await tflClient.GetAsync(endpointUrl);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    JArray joResponse = JArray.Parse(content);

                    roadStatus = joResponse.Select(r => new RoadStatus
                    {
                        DisplayName = (string) r["displayName"],
                        StatusSeverity = (string) r["statusSeverity"],
                        StatusSeverityDescription = (string) r["statusSeverityDescription"],
                        RoadFound = true
                    })
                    .FirstOrDefault();

                    return roadStatus;
                }
                else
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        _logger.LogInfo($"Road status data not found for Road Id: {roadId}");
                        roadStatus = new RoadStatus
                        {
                            DisplayName = roadId,
                            RoadFound = false
                        };
                    }
                    else
                    {
                        _logger.LogError($"Unexpected response from Tfl API: {response.StatusCode.ToString()}");
                        throw new RoadStatusApiException(response.ReasonPhrase.ToString());
                    }
            }

            return roadStatus;
        }
    }
}
