using RoadStatusShared.Service.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using RoadStatusApi.Model;
using Xunit;

namespace RoadStatusSharedTest.Service.Builder
{
    public class RoadStatusSeverityMessageBuilderTest
    {
        private RoadStatusSeverityMessageBuilder _builder;
        private const string Message = "        Road Status is Good";

        public RoadStatusSeverityMessageBuilderTest()
        {
            _builder = new RoadStatusSeverityMessageBuilder();
        }

        [Fact]
        public void RoadStatusSeverityMessageBuilderOrderIs2()
        {
            //Assert
            Assert.Equal(2, _builder.Order);
        }

        [Fact]
        public void RoadStatusReturnsBuiltMessageWhenRoadSeverityIsProvidedAndRoadFoundIsTrue()
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
            Assert.Equal(Message, result.Message);
        }

        [Fact]
        public void RoadStatusIsErrorIsFalseWhenSeverityIsProvidedAndRoadFoundIsTrue()
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
