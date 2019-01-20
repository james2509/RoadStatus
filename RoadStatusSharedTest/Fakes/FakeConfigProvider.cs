using System;
using System.Collections.Generic;
using System.Text;
using ConfigProvider;

namespace RoadStatusSharedTest.Fakes
{
    public class FakeConfigProvider : IConfigurationProvider
    {
        public Configuration GetConfiguration()
        {
            return new Configuration();
        }
    }
}
