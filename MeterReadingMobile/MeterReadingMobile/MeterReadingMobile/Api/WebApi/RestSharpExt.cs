using MeterReadingMobile.WebApi.Intrata.Model;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterReadingMobile.WebApi.Intrata
{
    public static class RestSharpExt
    {
        public static async Task<T> ExecuteAsync<T>(this RestRequest request, LoginUserBase currentUser, bool authorization = true) where T : new()
        {
            var client = new RestClient();
            var taskCompletionSource = new TaskCompletionSource<T>();
            client.BaseUrl = currentUser.url;
            if (authorization)
                request.AddHeader("Authorization", currentUser.token); // used on every request


            var tcs = new TaskCompletionSource<T>();
            await client.Execute<T>(request).ContinueWith(restResponse =>
            {
                if (restResponse.Exception != null)
                {
                    const string message = "Error retrieving response.";
                    tcs.SetException(new InvalidOperationException(message, restResponse.Exception));
                }
                else
                {
                    tcs.SetResult(restResponse.Result.Data);

                }
            });
            return await tcs.Task;
        }


        public static RestRequest PrepareRequestJson(string resource, Method method)
        {
            RestRequest request = new RestRequest() { Method = method };
            request.Resource = resource;

            return request;

        }
    }
}
