using System;
using System.Collections.Generic;
using System.Text;
using RoadStatusApi.Model;
using RoadStatusShared.Model;
using RoadStatusShared.Service;

namespace RoadStatusShared.Interface
{
    /// <summary>
    /// Interface for builders to build messages from Travel data
    /// </summary>
    public interface IMessageBuilder
    {
        /// <summary>
        /// Order in the Chain that the builder should be run
        /// </summary>
        int Order { get; }

        /// <summary>
        /// Get message from road status data
        /// </summary>
        /// <param name="roadStatus"></param>
        /// <returns></returns>
        RoadStatusMessage GetMessage(RoadStatus roadStatus);
    }
}
