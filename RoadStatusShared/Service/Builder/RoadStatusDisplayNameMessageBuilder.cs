using System;
using System.Collections.Generic;
using System.Text;
using RoadStatusApi.Model;
using RoadStatusShared.Interface;
using RoadStatusShared.Model;

namespace RoadStatusShared.Service.Builder
{
    public class RoadStatusDisplayNameMessageBuilder : IMessageBuilder
    {
        public int Order => 1;

        public RoadStatusMessage GetMessage(RoadStatus roadStatus)
        {
            if (roadStatus.RoadFound)
            {
                var message = $"The status of the {roadStatus.DisplayName} is as follows";
                var statusMessage = new RoadStatusMessage {IsError = false, Message = message };
                return statusMessage;
            }

            return null;
        }
    }
}
