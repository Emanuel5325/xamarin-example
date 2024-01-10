using Models.Work;
using System.Threading.Tasks;

namespace Services.Work
{
    internal class WorkApiClient : IWorkApiClient
    {
        public Task<ApiRequestResult<WorkData>> All(int page = 0, int pageSize = 100)
        {
            throw new System.NotImplementedException();
        }
    }
}
