using System;
using System.Collections.Generic;
using System.Text;
using ConfigProvider;
using Logging;
using RoadStatusApi.Model;
using RoadStatusShared.Service;
using RoadStatusSharedTest.Fakes;
using Xunit;

namespace RoadStatusSharedTest.Service
{
    public class RoadStatusServiceTest
    {
        private ILogger _logger;

        public RoadStatusServiceTest()
        {
            _logger = new FakeLogger();
        }

        [Fact]
        public void ValidateThreeInfoMessagesReturnedInSuccessScenario()
        {
            //Arrange
            var api = new FakeApi(roadId => new RoadStatus
            {
                DisplayName = "A2", RoadFound = true, StatusSeverity = "Good",
                StatusSeverityDescription = "No Exceptional Delays"
            });
            var service = new RoadStatusService(_logger, api);

            //Act
            var result = service.GetRoadStatusAsync("A2").Result;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.InfoMessages.Count);
        }

        [Fact]
        public void ValidateApplicationReturnCodeIsZeroInSuccessScenario()
        {
            //Arrange
            var api = new FakeApi(roadId => new RoadStatus
            {
                DisplayName = "A2",
                RoadFound = true,
                StatusSeverity = "Good",
                StatusSeverityDescription = "No Exceptional Delays"
            });
            var service = new RoadStatusService(_logger, api);

            //Act
            var result = service.GetRoadStatusAsync("A2").Result;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.ApplicationReturnCode);
        }

        [Fact]
        public void ValidateOneInfoMessagesReturnedInErrorScenario()
        {
            //Arrange
            var api = new FakeApi(roadId => new RoadStatus
            {
                DisplayName = "A333",
                RoadFound = false
            });
            var service = new RoadStatusService(_logger, api);

            //Act
            var result = service.GetRoadStatusAsync("A333").Result;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.InfoMessages.Count);
        }

        [Fact]
        public void ValidateApplicationReturnCodeIsOneInErrorScenario()
        {
            //Arrange
            var api = new FakeApi(roadId => new RoadStatus
            {
                DisplayName = "A333",
                RoadFound = false
            });
            var service = new RoadStatusService(_logger, api);

            //Act
            var result = service.GetRoadStatusAsync("A333").Result;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.ApplicationReturnCode);
        }
    }
}
