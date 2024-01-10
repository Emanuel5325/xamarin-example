using Models.Work;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace Services.Work
{
    internal class WorkApiClient : IWorkApiClient
    {

        public WorkData All(int page = 0, int pageSize = 100)
        {
            //WorkData work = new WorkData
            //{
            //    Name = "prueba",
            //    Id = 3,
            //};

            //ApiRequestResult<WorkData> response = new ApiRequestResult<WorkData> { Data = work, HasError = false, };

            //return Task.FromResult(response);




            // Crea una instancia de HttpClient
            HttpClient client = new HttpClient();

            // Define la URL de la API
            string uri = $"works/all?page={page}&pageSize={pageSize}";

            // Realiza la solicitud GET
            HttpResponseMessage response = client.GetAsync(uri).Result;

            // Verifica el código de estado de la respuesta
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Decodifica la respuesta
                string responseBody = response.Content.ReadAsStringAsync().Result;

                // Imprime la respuesta
                Console.WriteLine(responseBody);

                return JsonConvert.DeserializeObject<WorkData>(responseBody);
            }
            else
            {
                // Imprime un error
                Console.WriteLine("Error: {0}", response.StatusCode);

                return null;
            }
        }
    }
}
