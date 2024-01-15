using Models.Work;
using Newtonsoft.Json;
using RestSharp;
using Services.Work;
using System;
using System.Collections.Generic;

namespace XamarinExample.Services.Work
{
    internal class WorkApiClient : IWorkApiClient
    {

        public List<WorkData> All(int page = 0, int pageSize = 100)
        {
            //return new List<WorkData>()
            //{
            //    new WorkData
            //    {
            //        Name = "prueba",
            //        Id = 3,
            //    }
            //};


            RestClient client = new RestClient("http://10.0.2.2:5501");

            string uri = $"/api/works/all";

            RestRequest request = new RestRequest(uri, Method.Get);

            request = request.AddQueryParameter("page", page);
            request = request.AddQueryParameter("pageSize", pageSize);

            RestResponse response = client.GetAsync(request).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string responseBody = response.Content;

                Console.WriteLine(responseBody);

                return JsonConvert.DeserializeObject<List<WorkData>>(responseBody);
            }
            else
            {
                Console.WriteLine("Error: {0}", response.StatusCode);

                return null;
            }

        }
    }
}
