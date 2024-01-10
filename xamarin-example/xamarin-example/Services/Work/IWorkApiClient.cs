using System.Threading.Tasks;

namespace Services.Work
{
    internal interface IWorkApiClient
    {
        Task<APIRequestResult<WorkData>> Get(int page = 0, int pageSize = 100);
    }
}
