using MauiExample.Models.Work;

namespace MauiExample.Services.Work
{
    internal class WorkApiClient : IWorkApiClient
    {
        public List<WorkData> All(int page = 0, int pageSize = 100)
        {
            return
            [
                new() { Name = "prueba", Id = 3, }
            ];

            //RestClient client = new("http://10.0.2.2:5501");

            //string uri = $"/api/works/all";

            //RestRequest request = new(uri, Method.Get);

            //request = request.AddQueryParameter("page", page);
            //request = request.AddQueryParameter("pageSize", pageSize);

            //RestResponse response = client.GetAsync(request).Result;

            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    string responseBody = response.Content;

            //    Console.WriteLine(responseBody);

            //    return JsonConvert.DeserializeObject<List<WorkData>>(responseBody);
            //}
            //else
            //{
            //    Console.WriteLine("Error: {0}", response.StatusCode);

            //    return null;
            //}
        }
    }
}
