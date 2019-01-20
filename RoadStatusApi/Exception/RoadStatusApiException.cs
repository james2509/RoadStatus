using System;
using System.Collections.Generic;
using System.Text;

namespace RoadStatusApi.Exception
{
    public class RoadStatusApiException : System.Exception
    {
        public RoadStatusApiException(string message) : base(message)
        {

        }
    }
}
