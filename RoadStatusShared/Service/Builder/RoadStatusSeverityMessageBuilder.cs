using System;
using System.Collections.Generic;
using System.Text;
using RoadStatusApi.Model;
using RoadStatusShared.Interface;
using RoadStatusShared.Model;

namespace RoadStatusShared.Service.Builder
{
    public class RoadStatusSeverityMessageBuilder : IMessageBuilder
    {
        public int Order => 2;

        public RoadStatusMessage GetMessage(RoadStatus roadStatus)
        {
            if (roadStatus.RoadFound)
            {
                var message = $"        Road Status is {roadStatus.StatusSeverity}";
                var statusMessage = new RoadStatusMessage { IsError = false, Message = message };
                return statusMessage;
            }

            return null;
        }
    }
}
