using System;
using ConfigProvider.Exceptions;

namespace ConfigProvider
{
    /// <summary>
    /// Class to hold configuration data as loaded from the configuration provider
    /// </summary>
    public class Configuration
    {
        public string TflRoadSummaryEndpoint { get; set; }

        public string TflApplicationId { get; set; }

        public string TflDeveloperKey { get; set; }

        /// <summary>
        /// Get a built REST Url to call to Tfl Road API
        /// </summary>
        /// <param name="roadId"></param>
        /// <returns></returns>
        public string GetRoadSummaryEndPoint(string roadId)
        {
            if (String.IsNullOrEmpty(TflApplicationId) || String.IsNullOrEmpty(TflDeveloperKey) ||
                String.IsNullOrEmpty(roadId) || String.IsNullOrEmpty(TflRoadSummaryEndpoint))
            {
                throw new RoadSummaryConfigException("One or more required endpoint configuration parameters are missing");
            }

            return String.Format(TflRoadSummaryEndpoint, roadId, TflApplicationId, TflDeveloperKey);
        }
    }
}
