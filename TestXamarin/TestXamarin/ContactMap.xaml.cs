using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestXamarin.Class;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TestXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactMap : ContentPage
	{
        public ContactMap(Users personne)
        {
            InitializeComponent();
            ApiGestion api = new ApiGestion("https://api-adresse.data.gouv.fr/search/");
            var dataGouv = api.GetPositionByAdress(personne.Adress);

            float lat = dataGouv.features[0].geometry.coordinates[0];
            float lon = dataGouv.features[0].geometry.coordinates[1];

            map.MoveToRegion(new MapSpan(new Position(Convert.ToDouble(lon), Convert.ToDouble(lat)), 0.005, 0.005));

            //Création d'un point d'interet
            Pin pin = new Pin()
            {
                Label = personne.Name,
                Address = personne.Adress,
                Position = new Position(lat, lon)
            };

            pin.Clicked += OnPinCliked;
            map.Pins.Add(pin);

		}

        private void OnPinCliked(object sender, EventArgs e)
        {
            
        }
    }
}