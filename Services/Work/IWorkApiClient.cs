using MauiExample.Models.Work;

namespace MauiExample.Services.Work
{
    internal interface IWorkApiClient
    {
        List<WorkData> All(int page = 0, int pageSize = 100);
    }
}
