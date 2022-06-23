using N2_App.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Correios;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using RestSharp;
using System.Net.Http;




namespace N2_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }


        // Api utilizada: //https://docs.awesomeapi.com.br/api-de-moedas

        private void moedas_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private async void btnProcurar_Clicked(object sender, EventArgs e)
        {


            try
            {

                if (entDias.Text != null)
                {
                    var conjuntoConversao = moedas.Items[moedas.SelectedIndex];

                    HttpClient http = new HttpClient();

                    http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

                    http.BaseAddress = new System.Uri("https://economia.awesomeapi.com.br/"); 

                    HttpResponseMessage unificaDados = await http.GetAsync($"json/daily/{conjuntoConversao}/{entDias.Text}");

                    var result = await unificaDados.Content.ReadAsStringAsync();
                    lblMd01.Text = result.ToString().Replace(',', '\n').Replace('"', ' ').Replace('}', ' ');
                }
                else
                {
                    await DisplayAlert("Campos vázios", "Tente novamente", "ok");
                }

            
            }
            catch(Exception erro)
            {
                Console.WriteLine(erro);    
            }



        }
    }
}