using RoadStatusShared.Service.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using RoadStatusApi.Model;
using Xunit;

namespace RoadStatusSharedTest.Service.Builder
{
    public class RoadStatusNotFoundMessageBuilderTest
    {
        private RoadStatusNotFoundMessageBuilder _builder;
        private const string Message = "A233 is not a valid road";

        public RoadStatusNotFoundMessageBuilderTest()
        {
            _builder = new RoadStatusNotFoundMessageBuilder();
        }

        [Fact]
        public void RoadStatusDisplayNameMessageBuilderOrderIs1()
        {
            //Assert
            Assert.Equal(1, _builder.Order);
        }

        [Fact]
        public void RoadStatusReturnsBuiltMessageWhenRoadFoundIsFalse()
        {
            //Arrange
            var roadStatus = new RoadStatus
            {
                DisplayName = "A233",
                RoadFound = false
            };

            //Act
            var result = _builder.GetMessage(roadStatus);

            //Assert
            Assert.Equal(Message, result.Message);
        }

        [Fact]
        public void RoadStatusIsErrorIsTrueWhenRoadFoundIsFalse()
        {
            //Arrange
            var roadStatus = new RoadStatus
            {
                DisplayName = "A233",
                RoadFound = false
            };

            //Act
            var result = _builder.GetMessage(roadStatus);

            //Assert
            Assert.True(result.IsError);
        }

        [Fact]
        public void NullIsReturnIfRoadFoundIsTrue()
        {
            //Arrange
            var roadStatus = new RoadStatus
            {
                RoadFound = true
            };

            //Act
            var result = _builder.GetMessage(roadStatus);

            //Assert
            Assert.Null(result);
        }
    }
}
