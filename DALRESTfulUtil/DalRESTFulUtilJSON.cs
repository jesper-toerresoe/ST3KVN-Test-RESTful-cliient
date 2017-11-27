﻿using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace DALRESTfulUtil.HttpClientJson
{

    /**
    * http://stackoverflow.com/questions/2546138/deserializing-json-data-to-c-sharp-using-json-net 
    * https://jsonclassgenerator.codeplex.com/downloads/get/631627
    * http://www.asp.net/web-api/overview/advanced/calling-a-web-api-from-a-net-client
    **/

    public class APIGetJSON<T>
    {
        public T data;
        private string url;

        public APIGetJSON(string geturl)
        {
            url = geturl;
            data = getItems();
        }

        private T getItems()
        {
            T result = default(T);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // This allows for debugging possible JSON issues
            var settings = new JsonSerializerSettings
            {
                Error = (sender, args) =>
                {
                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        System.Diagnostics.Debugger.Break();
                    }
                }
            };

            using (HttpResponseMessage response = client.GetAsync(this.url).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string resp = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<T>(resp, settings);
                }
            }
            return result;
        }
    }


    /// <summary>
    /// Uses the .NET deserializer instead of Newtonsoft JSON deserializer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class APIGetJSONAsync<T>
    {
        public T data;
        private string url;
        async Task RunConsumer()
        {
            data = await getItems();
        }

        public APIGetJSONAsync(string geturl)
        {
            url = geturl;
            RunConsumer().Wait();
        }

        private async Task<T> getItems()
        {
            T result = default(T);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (HttpResponseMessage response = client.GetAsync(this.url).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<T>();

                }
            }
            return result;
        }
    }

    public class APIPostJSON<T>
    {
        public T data;
        private string url;
        private string request;

        public APIPostJSON(string geturl, string req, T item)
        {
            data = item;
            request = req;
            url = geturl;
            data = postItem(item);
        }

        private T postItem(T item)
        {
            T result = default(T);
            result = item;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            //client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (HttpResponseMessage response = client.PostAsJsonAsync(request, item).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                }
            }
            return result;
        }
    }
    /// <summary>
    /// Uses the .NET deserializer instead of Newtonsoft JSON deserializer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class APIPostJSONAsync<T>
    {
        public T data;
        private string url;
        private string request;

        async Task RunConsumer()
        {           
            data = await postItem(data); 
        }

        public APIPostJSONAsync(string geturl, string req, T item)
        {
            data = item;
            request = req;
            url = geturl;
            RunConsumer().Wait();
        }

        private async Task<T> postItem(T item)
        {
            T result = default(T);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (HttpResponseMessage response = client.PostAsJsonAsync(request, item).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                    result = await response.Content.ReadAsAsync<T>();
                }
            }
            return result;

        }
    }
    public class APIPutJSON<T>
    {
        public T data;
        private string url;
        private string request;

        public APIPutJSON(string puturl, string req, T item)
        {
            data = item;
            request = req;
            url = puturl;
            data = putItem(item);
        }

        private T putItem(T item)
        {
            T result = default(T);
            result = item;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (HttpResponseMessage response = client.PutAsJsonAsync(request, item).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                }
            }
            return result;
        }
    }

    public class APIDeleteJSON<T>
    {
        public T data;
        private string url;
        private string request;
        
        public APIDeleteJSON(string deleteurl, string req, T item)
        {
            data = item;
            request = req;
            url = deleteurl;
            data = deleteItem(item);
        }

        private T deleteItem(T item)
        {
            T result = default(T);
            result = item;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (HttpResponseMessage response = client.DeleteAsync(request).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    string resp = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<T>(resp);
                }
            }
            return result;
        }
    }

    public class APIDeleteJSONAsynch<T>
    {
        public T data;
        private string url;
        private string request;

        async Task RunConsumer()
        {
            data = await deleteItem(data);
        }

        public APIDeleteJSONAsynch(string deleteurl, string req, T item)
        {
            data = item;
            request = req;
            url = deleteurl;
            RunConsumer().Wait();
        }

        private async Task<T> deleteItem(T item)
        {
            T result = default(T);
            result = item;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (HttpResponseMessage response = client.DeleteAsync(request).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    /*
                     * Severity	Code	Description	Project	File	Line	Suppression StateWarning	CS0618	'JsonConvert.DeserializeObjectAsync<T>(string)' is obsolete: 
                     * 'DeserializeObjectAsync is obsolete. Use the Task.Factory.StartNew method to deserialize JSON asynchronously: Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(value))'	DALRESTfulUtil	C:\Users\jrt\Source\Repos\ST3ComponetsAndConnections\DALRESTfulUtil\DalRESTFulUtilJSON.cs	194	Active
                      */
                    //result = await JsonConvert.DeserializeObjectAsync<T>(response.Content.ReadAsStringAsync().Result);
                    //result = await JsonConvert.DeserializeObjectAsync<T>();
                    result = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result));
                }
            }
            return result;
        }
    }

}
