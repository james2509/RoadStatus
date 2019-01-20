using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ConfigProvider.Exceptions;
using Newtonsoft;
using Newtonsoft.Json;
using Logging;

namespace ConfigProvider
{
    public class JsonFileConfigurationProvider : IConfigurationProvider
    {
        private Configuration _configuration;
        private ILogger _logger;

        public JsonFileConfigurationProvider(ILogger logger)
        {
            _logger = logger;
            _logger.LogInfo("Loading configuration from JSON File");

            try
            {
                var stringConfig = File.ReadAllText(@"config.json");
                _configuration = JsonConvert.DeserializeObject<Configuration>(stringConfig);
            }
            catch (Exception e)
            {
                _logger.LogException(e);
                throw new RoadSummaryConfigException(e.Message);
            }

            if (_configuration == null)
            {
                _logger.LogError("Config file read and deserialised to null");
                throw new RoadSummaryConfigException("Config is null");
            }
        }

        public Configuration GetConfiguration()
        {
            return _configuration;
        }
    }
}
