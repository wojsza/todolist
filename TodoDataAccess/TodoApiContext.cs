using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TodoDataAccess
{
    public class TodoApiContext
    {
        public string BaseAddress { get; set; } = @"http://localhost:5000";

        public string ContentType { get; set; } = @"application/json";

        public HttpClient Client { get; private set; }

        public TodoApiContext()
        {
            Init();
        }

        private void Init()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(BaseAddress);

            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue(ContentType);
            Client.DefaultRequestHeaders.Accept.Add(contentType);
        }
    }
}
