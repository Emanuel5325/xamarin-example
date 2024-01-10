using Models.Work;

namespace Services.Work
{
    internal class WorkApiClient : IWorkApiClient
    {

        public WorkData All(int page = 0, int pageSize = 100)
        {
            return new WorkData
            {
                Name = "prueba",
                Id = 3,
            };





            //// Crea una instancia de HttpClient
            //HttpClient client = new HttpClient();

            //// Define la URL de la API
            //string uri = $"http://localhost:5501/api/works/all?page={page}&pageSize={pageSize}";

            //// Realiza la solicitud GET
            //HttpResponseMessage response = client.GetAsync(uri).Result;

            //// Verifica el código de estado de la respuesta
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    // Decodifica la respuesta
            //    string responseBody = response.Content.ReadAsStringAsync().Result;

            //    // Imprime la respuesta
            //    Console.WriteLine(responseBody);

            //    return JsonConvert.DeserializeObject<WorkData>(responseBody);
            //}
            //else
            //{
            //    // Imprime un error
            //    Console.WriteLine("Error: {0}", response.StatusCode);

            //    return null;
            //}






            //// Crea una instancia de RestClient
            //RestClient client = new RestClient("http://localhost:5501");

            //// Define la URL de la API
            //string uri = $"/api/works/all";

            //RestRequest request = new RestRequest(uri);

            //request = request.AddQueryParameter("page", page);
            //request = request.AddQueryParameter("pageSize", pageSize);

            //// Realiza la solicitud GET
            //RestResponse response = client.GetAsync(request).Result;

            //// Verifica el código de estado de la respuesta
            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    // Decodifica la respuesta
            //    string responseBody = response.Content;

            //    // Imprime la respuesta
            //    Console.WriteLine(responseBody);

            //    return JsonConvert.DeserializeObject<WorkData>(responseBody);
            //}
            //else
            //{
            //    // Imprime un error
            //    Console.WriteLine("Error: {0}", response.StatusCode);

            //    return null;
            //}

        }
    }
}
