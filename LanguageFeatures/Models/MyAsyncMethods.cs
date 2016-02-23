using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace LanguageFeatures.Models {
    public class MyAsyncMethods {
        public static Task<long?> GetPageLength() {
            HttpClient client = new HttpClient();

            var httpTask = client.GetAsync("http://apress.com");

            // we could do other things here while we are waiting
            // for the HTTP request to complete

            return httpTask.ContinueWith((Task<HttpResponseMessage> antedecent) => {
                return antedecent.Result.Content.Headers.ContentLength;
            });
        }

        public async static Task<long?> AwaitGetPageLength() {
            HttpClient client = new HttpClient();

            var httpMesage = await client.GetAsync("http://apress.com");

            // we could do other things here while we are waiting
            // for the HTTP request to complete

            return httpMesage.Content.Headers.ContentLength;
        }
    }
}