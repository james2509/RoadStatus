using RoadStatusApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoadStatusApi.Interface
{
    /// <summary>
    /// Interface definition to provide road status information from implemented Apis 
    /// </summary>
    public interface IRoadStatusApi
    {
        /// <summary>
        /// Get road status data for a specified road
        /// </summary>
        Task<RoadStatus> GetRoadStatusAsync(string roadId);
    }
}
