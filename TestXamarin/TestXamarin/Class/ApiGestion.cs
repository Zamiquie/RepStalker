using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestXamarin.Class
{
    public class ApiGestion
    { 
        public string Url { get; set; }
        public int Port { get; set; }
        public string Domaine { get; set; }
        public RestClient Client { get; set; }

        //Constructeur par default 
        public ApiGestion()
        {
            if (Device.RuntimePlatform == Device.Android) Domaine = "10.0.0.2";
            else Domaine = "localhost";

            Port = 50565;
            Url = "http://" + Domaine + ":" + Port.ToString() + "/api/projet/" ;
            Client = new RestClient(Url);

        }

        public ApiGestion(string url)
        {
            Url = url;
            Client = new RestClient(Url);
        }

        public List<Users> AllUser()
        {
            string ressource = "Users/AllUsers";
            var request = new RestRequest(ressource,Method.GET);

            //envoie request
            request.OnBeforeDeserialization = resp => resp.ContentType = "application/json";
            request.Timeout = 150;
            IRestResponse reponse = Client.Execute(request);
            var content = reponse.Content;
            var Json = JsonConvert.DeserializeObject<List<Users>>(content);

            return Json;
        }

        public List<OSMReturn> GetPositionByAdress(string ressource,string formatOutp,string address)
        {
            string uri = ressource + "?format="+formatOutp + "&q="+Uri.EscapeUriString(address);
            var request = new RestRequest(uri, Method.GET);

            //envoie request
            request.OnBeforeDeserialization = resp => resp.ContentType = "application/json";
            IRestResponse reponse = Client.Execute(request);
            var content = reponse.Content;
            var json = JsonConvert.DeserializeObject<List<OSMReturn>>(content);

            return json;


        }

    }
}
