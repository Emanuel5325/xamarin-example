using Models.Work;
using System.Threading.Tasks;

namespace Services.Work
{
    internal interface IWorkApiClient
    {
        Task<ApiRequestResult<WorkData>> All(int page = 0, int pageSize = 100);
    }
}
