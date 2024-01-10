using Models.Work;
using System.Collections.Generic;

namespace Services.Work
{
    internal interface IWorkApiClient
    {
        List<WorkData> All(int page = 0, int pageSize = 100);
    }
}
