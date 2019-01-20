using RoadStatusShared.Service.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using RoadStatusApi.Model;
using Xunit;

namespace RoadStatusSharedTest.Service.Builder
{
    public class RoadStatusSeverityDescriptionMessageBuilderTest
    {
        private RoadStatusSeverityDescriptionMessageBuilder _builder;
        private const string Message = "        Road Status Description is No Exceptional Delays";

        public RoadStatusSeverityDescriptionMessageBuilderTest()
        {
            _builder = new RoadStatusSeverityDescriptionMessageBuilder();
        }

        [Fact]
        public void RoadStatusSeverityDescriptionMessageBuilderOrderIs3()
        {
            //Assert
            Assert.Equal(3, _builder.Order);
        }

        [Fact]
        public void RoadStatusReturnsBuiltMessageWhenRoadSeverityDescriptionIsProvidedAndRoadFoundIsTrue()
        {
            //Arrange
            var roadStatus = new RoadStatus
            {
                DisplayName = "A2",
                RoadFound = true,
                StatusSeverity = "Good",
                StatusSeverityDescription = "No Exceptional Delays"
            };

            //Act
            var result = _builder.GetMessage(roadStatus);

            //Assert
            Assert.Equal(Message, result.Message);
        }

        [Fact]
        public void RoadStatusIsErrorIsFalseWhenSeverityDescriptionIsProvidedAndRoadFoundIsTrue()
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
