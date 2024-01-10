using Models.Work;
using System.Threading.Tasks;

namespace Services.Work
{
    internal class WorkApiClient : IWorkApiClient
    {
        public Task<APIRequestResult<WorkData>> Get(int page = 0, int pageSize = 100)
        {
            throw new System.NotImplementedException();
        }

        Task<APIRequestResult<WorkData>> IWorkApiClient.Get(int page, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        Task<APIRequestResult<WorkData>> IWorkApiClient.Get(int page, int pageSize)
        {
            throw new System.NotImplementedException();
        }
    }
}
