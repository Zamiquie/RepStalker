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


    public class OSMReturn
    {
        public int place_id { get; set; }
        public string licence { get; set; }
        public string osm_type { get; set; }
        public int osm_id { get; set; }
        public string[] boundingbox { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string display_name { get; set; }
        public string _class { get; set; }
        public string type { get; set; }
        public float importance { get; set; }
    }



}
