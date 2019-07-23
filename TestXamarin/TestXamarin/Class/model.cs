using System;
using System.Collections.Generic;
using System.Text;

namespace TestXamarin.Class
{
    public class Users
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Telephone { get; set; }
    }



  
    public class DataGouvApiReturn
    {
        public string type { get; set; }
        public string version { get; set; }
        public Feature[] features { get; set; }
        public string attribution { get; set; }
        public string licence { get; set; }
        public string query { get; set; }
        public int limit { get; set; }
    }
    #region ApiGouv
    public class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public float[] coordinates { get; set; }
    }

    public class Properties
    {
        public string label { get; set; }
        public float score { get; set; }
        public string housenumber { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string postcode { get; set; }
        public string citycode { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public string city { get; set; }
        public string context { get; set; }
        public float importance { get; set; }
        public string street { get; set; }
    }
    #endregion



}
