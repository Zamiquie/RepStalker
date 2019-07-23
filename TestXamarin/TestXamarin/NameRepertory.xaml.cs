using Android.Content;
using Android.Provider;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TestXamarin.Class;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NameRepertory : ContentPage
    {
        
        public ApiGestion Api { get; set; }

        //Test en dur(voir en DB)
        public List<Users> Users { get; set; }

        [Obsolete]
        public NameRepertory()
        {
            InitializeComponent();

            Users = new List<Users>();
            Api = new ApiGestion();

            if (Api.AllUser() != null)
            {
                foreach (Users user in Api.AllUser())
                {
                    Users.Add(user);
                }
            }
            else
            {
                
               

                foreach (var user in Plugin.ContactService.CrossContactService.Current.GetContactListAsync().Result)
                {
                    Users.Add(new Users()
                    {
                        Name = user.Name,
                        Telephone = user.Number,
                        Adress = "65 Rue Louis Becker 69100 Villeurbanne"
                    }
                    
                }
)
                Users = Users.OrderBy(m => m.Name).ToList();
               
            }

            MyListView.ItemsSource = Users;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            Users Personne = ((Users)e.Item);
            var Display = await DisplayAlert(Personne.Name, Personne.Adress + "\n" + Personne.PostalCode + " " + Personne.City, "Appeler", "Rechercher sur la carte");

            if (Display)
            {
                var PhoneCallTask = CrossMessaging.Current.PhoneDialer;
                if (PhoneCallTask.CanMakePhoneCall) PhoneCallTask.MakePhoneCall(Personne.Telephone);
            }
            if (!Display)
            {

                await Navigation.PushAsync(new ContactMap(Personne));
            }

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        
    }
}
