using RoadStatusShared.Service.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using RoadStatusApi.Model;
using Xunit;

namespace RoadStatusSharedTest.Service.Builder
{
    public class RoadStatusDisplayNameMessageBuilderTest
    {
        private RoadStatusDisplayNameMessageBuilder _builder;
        private const string Message = "The status of the A2 is as follows";

        public RoadStatusDisplayNameMessageBuilderTest()
        {
            _builder = new RoadStatusDisplayNameMessageBuilder();
        }

        [Fact]
        public void RoadStatusDisplayNameMessageBuilderOrderIs1()
        {
            //Assert
            Assert.Equal(1, _builder.Order);
        }

        [Fact]
        public void RoadStatusReturnsBuiltMessageWhenRoadNameIsProvidedAndRoadFoundIsTrue()
        {
            //Arrange
            var roadStatus = new RoadStatus
            {
                DisplayName = "A2", RoadFound = true, StatusSeverity = "Good",
                StatusSeverityDescription = "No Exceptional Delay"
            };

            //Act
            var result = _builder.GetMessage(roadStatus);

            //Assert
            Assert.Equal(Message, result.Message);
        }

        [Fact]
        public void RoadStatusIsErrorIsFalseWhenRoadNameIsProvidedAndRoadFoundIsTrue()
        {
            //Arrange
            var roadStatus = new RoadStatus
            {
                DisplayName = "A2",
                RoadFound = true,
                StatusSeverity = "Good",
                StatusSeverityDescription = "No Exceptional Delay"
            };

            //Act
            var result = _builder.GetMessage(roadStatus);

            //Assert
            Assert.False(result.IsError);
        }

        [Fact]
        public void NullIsReturnIfRoadFoundIsFalse()
        {
            //Arrange
            var roadStatus = new RoadStatus
            {
                RoadFound = false
            };

            //Act
            var result = _builder.GetMessage(roadStatus);

            //Assert
            Assert.Null(result);
        }
    }
}
