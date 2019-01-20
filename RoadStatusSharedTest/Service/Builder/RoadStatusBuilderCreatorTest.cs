using System;
using System.Collections.Generic;
using System.Text;
using RoadStatusShared.Service.Builder;
using Xunit;

namespace RoadStatusSharedTest.Service.Builder
{
    public class RoadStatusBuilderCreatorTest
    {
        [Fact]
        public void CorrectNumberOfBuilderTypesAreCreated()
        {
            //Act
            var list = RoadStatusBuilderCreator.CreateBuilders();

            //Assert
            Assert.Equal(4, list.Count);
        }
    }
}
