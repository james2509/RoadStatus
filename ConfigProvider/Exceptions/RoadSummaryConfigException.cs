using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigProvider.Exceptions
{
    public class RoadSummaryConfigException : ArgumentException
    {
        public RoadSummaryConfigException(string message) : base(message)
        {
        }
    }
}
