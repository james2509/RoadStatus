using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RoadStatusApi.Interface;
using RoadStatusApi.Model;

namespace RoadStatusSharedTest.Fakes
{
    public class FakeApi : IRoadStatusApi
    {
        private Func<string, RoadStatus> _predicate;

        public FakeApi(Func<string, RoadStatus> predictate)
        {
            _predicate = predictate;
        }

        public async Task<RoadStatus> GetRoadStatusAsync(string roadId)
        {
            return Task.FromResult(_predicate(roadId)).Result;
        }
    }
}
