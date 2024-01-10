using Models.Work;
using System.Threading.Tasks;

namespace Services.Work
{
    internal class WorkApiClient : IWorkApiClient
    {
        public Task<ApiRequestResult<WorkData>> All(int page = 0, int pageSize = 100)
        {
            WorkData work = new WorkData
            {
                Name = "prueba",
                Id = 3,
            };

            ApiRequestResult<WorkData> response = new ApiRequestResult<WorkData> { Data = work, HasError = false, };

            return Task.FromResult(response);
        }
    }
}
