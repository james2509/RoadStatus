using System;
using System.Collections.Generic;
using System.Text;
using RoadStatusApi.Model;
using RoadStatusShared.Interface;
using RoadStatusShared.Model;

namespace RoadStatusShared.Service.Builder
{
    public class RoadStatusNotFoundMessageBuilder : IMessageBuilder
    {
        public int Order => 1;

        public RoadStatusMessage GetMessage(RoadStatus roadStatus)
        {
            if (!roadStatus.RoadFound)
            {
                var message = $"{roadStatus.DisplayName} is not a valid road";
                var statusMessage = new RoadStatusMessage { IsError = true, Message = message};
                return statusMessage;
            }

            return null;
        }
    }
}
