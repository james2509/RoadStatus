using System;
using System.Collections.Generic;
using System.Text;
using RoadStatusApi.Model;
using RoadStatusShared.Interface;
using RoadStatusShared.Model;

namespace RoadStatusShared.Service.Builder
{
    public class RoadStatusSeverityDescriptionMessageBuilder : IMessageBuilder
    {
        public int Order => 3;

        public RoadStatusMessage GetMessage(RoadStatus roadStatus)
        {
            if (roadStatus.RoadFound)
            {
                var message = $"        Road Status Description is {roadStatus.StatusSeverityDescription}";
                var statusMessage = new RoadStatusMessage { IsError = false, Message = message };
                return statusMessage;
            }

            return null;
        }
    }
}
