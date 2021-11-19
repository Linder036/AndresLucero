using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using Xamarin.Forms; 

namespace AndresLucero
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.10.2/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AndresLucero.Ws.Datos> _post;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            
            var content = await client.GetStringAsync(Url);
            List<AndresLucero.Ws.Datos> posts = JsonConvert.DeserializeObject<List<AndresLucero.Ws.Datos>>(content);
            _post = new ObservableCollection<Ws.Datos>(posts);

            MyListView.ItemsSource = _post;

        }

        private void btnPost_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new viewInsertarB());
        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {

        }
    }
}
