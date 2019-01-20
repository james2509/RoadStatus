using System;
using ConfigProvider;
using ConfigProvider.Exceptions;
using Logging;
using RoadStatusSharedTest.Fakes;
using Xunit;

namespace ConfigProviderTest
{
    public class ConfigurationTest
    {
        private const string BuiltEndPoint = @"https://api.tfl.gov.uk/Road/A2?app_id=061b50e1& app_key=d0fc4da5d0ae282311eee0d5024b2f12";
        private const string BuiltEndPointConfigException = "One or more required endpoint configuration parameters are missing";

        [Fact]
        private void ValidateTflRoadEnpointIsBuildCorrectlyFromConfig()
        {
            //Arrange
            var provider = new JsonFileConfigurationProvider(new FakeLogger());

            //Act
            var endpointString = provider.GetConfiguration().GetRoadSummaryEndPoint("A2");

            //Assert
            Assert.Equal(endpointString, BuiltEndPoint);
        }

        [Fact]
        private void ExceptionIsThrownWhenConfigIsMissing()
        {
            //Arrange
            var provider = new JsonFileConfigurationProvider(new FakeLogger());

            //Assert
            var exception = Assert.Throws<RoadSummaryConfigException>(() => provider.GetConfiguration().GetRoadSummaryEndPoint(""));
            Assert.Equal(exception.Message, BuiltEndPointConfigException);
        }
    }
}
