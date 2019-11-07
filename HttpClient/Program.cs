using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace HttpClientTest
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            send();
        }

        static void send()
        {
         


            DelegatingHandler delegatingHandler;
            HttpMessageHandler httpMessageHandler;

            HttpClient _httpClient = new HttpClient();
            for (int i=0;i<100;i++)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff"));
                string requestContent = "{pageIndex: 1,pageSize: 10,Params: {}}";


                var hp = new StringContent(requestContent, Encoding.UTF8);
                var types = new MediaTypeHeaderValue("application/json");
                types.CharSet = "UTF-8";
                hp.Headers.ContentType = types;
                hp.Headers.Add("Cookie", ".WMS.Wms1=1i1%2B1X4Qx6mcfn8GDV0iWGq%2FI2Wl1l%2BzBET5RXahyZOD%2BhVNjnDyuhGMLxxdflAxlXBHjWvvBplFHbZdD9eCn%2FS8iA2mlFVXzIxWeAbkTvR%2FBc%2F4pZvjKqVXMRunHKgRUm2GmABTIXFi48XsvCQ0%2BMZ7hd2%2F2EVUA89FTqsbb4svxcON7RikrUvhzDzG3F2b35dUtxH8LQfu%2F1GqOruHyVqTNM8Ty8toWhBgdQ5%2BilYl8At%2FmM0OsDtgmak2glNhhdXIA4oLz7dwE8SMh%2BhEIQ%3D%3D; .WMS.Wms2=12D812FD12F412F012F712C712EE12E312FA; .WMS.Wms3=12A912A912A912A912A912A912A912A912B412A912A912A912A912B412A912A912A912A912B412A912A912A912A912B412A912A912A912A912A912A912A912A912A912A912A912A9");


                var postResult = new HttpResponseMessage();

                postResult = _httpClient.PostAsync("http://192.168.200.160:8200/tenant/api/tsysdict/getsysdicts", hp).Result;

                var responseContent = postResult.Content.ReadAsStringAsync().Result;

               // Console.WriteLine(responseContent);

                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff"));
            }
           
        }
    }

    class SendClass
    {
       public int pageIndex { get; set; }
        public int pageSize { get; set; }

        public Dictionary<string,string> Params { get; set; }
    }
}
