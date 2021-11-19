using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndresLucero
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class viewInsertarB : ContentPage
    {
        public viewInsertarB()
        {
            InitializeComponent();
        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                cliente.UploadValues("http://192.168.10.2/moviles/post.php", "POST", parametros);
                DisplayAlert("alerta", "Ingreso correcto", "ok");
            } 
            catch (Exception ex)
            {
                DisplayAlert("alerta", ex.Message, "ok");
            }
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}