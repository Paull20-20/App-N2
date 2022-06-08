using N2_App.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Correios;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace N2_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }


        private void btnProcurar_Clicked(object sender, EventArgs e)
        {

            try
            {

                if (string.IsNullOrEmpty(entCep.Text))
                {
                    DisplayAlert("Campo de busca do CEP vázio!", "Tente novamente", "Ok");
                }
                else
                {
                    CorreiosApi correios = new CorreiosApi();

                    Correios.CorreiosServiceReference.enderecoERP result = correios.consultaCEP(entCep.Text);
                  
                    lblCep2.Text = result.cep;
                    lblEstado.Text = result.uf;
                    lblCidade.Text = result.cidade;
                    lblBairro.Text = result.bairro;
                    lblRua.Text = result.end;


                }

            }

            catch(Exception ex)
            {
                DisplayAlert("Erro ao buscar cep, confira o erro abaixo!", ex.Message, "Tentar novamente!");
            }

        }
    }
}