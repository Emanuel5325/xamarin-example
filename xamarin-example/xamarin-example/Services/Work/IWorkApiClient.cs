using Models.Work;

namespace Services.Work
{
    internal interface IWorkApiClient
    {
        WorkData All(int page = 0, int pageSize = 100);
    }
}
