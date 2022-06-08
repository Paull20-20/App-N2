using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using N2_App.Class;

namespace N2_App
{
    
    public partial class MainPage : ContentPage
    {

        ClassBase cb = new Class.ClassBase();
        public bool tem;
        public string msg = "";

       // public string login = "Tiago22";
       // public string pass = "12345";

        public string Txt_email;
        public string Txt_senha;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnLogar_Clicked(object sender, EventArgs e)
        {
            ClassBase cb = new ClassBase();

            Txt_email = entLogin.Text;
            Txt_senha = entSenha.Text;

            try
            {

                if (entLogin.Text != null && entSenha.Text != null)
                {
                   

                    if (msg.Equals(""))
                    {
                        if (tem == false)
                        {
                            logando(Txt_email, Txt_senha);
                            await DisplayAlert("Logou", "uhu", "ok");
                            await Navigation.PushAsync(new Home());
                        }
                        else
                        {
                            await DisplayAlert("Login inválido", "tente novamente", "ok");
                       }
                    }

                    else
                    {
                        await DisplayAlert("Campos inválidos", "Tente novamente", "ok");
                    }

                }
                else
                {
                    await DisplayAlert("Campos inválidos", "Tente novamente", "ok");
                }



            }
            catch(Exception ex)
            {
                await DisplayAlert("Bug", ex.Message, "ok");
            }


        }

        public bool logando(string Txt_email, string Txt_senha)
        {


            tem = cb.verificarLogin(Txt_email, Txt_senha);

            if (!cb.msg.Equals("")) //se não for vázio deu b.o
            {
                this.msg = cb.msg;
            }

            return tem;


        }

        private async void btnCriarConta_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CriarConta());
            
        }


       

    }



}
