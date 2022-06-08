using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using N2_App.Class;
using System.Net;
using System.Net.Mail;

namespace N2_App

{
    

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CriarConta : ContentPage
    {
        public CriarConta()
        {
            InitializeComponent();
        }

        ClassBase cb = new Class.ClassBase();
        public string loginCadastro;
        public string senhaCadastro;
        public string confirmarsenhaCadastro;

        public string Txt_email;

        private void insert()
        {

            loginCadastro = entLoginCadastro.Text;
            senhaCadastro = entSenhaCadastro.Text;
            confirmarsenhaCadastro = entSenhaConfirmCadastro.Text;

            if (loginCadastro != null && senhaCadastro == confirmarsenhaCadastro)
            {
                try
                {
                    cb.Insert(loginCadastro, senhaCadastro);
                    DisplayAlert("Cadastro realizado com sucesso!", "Redirecionando para tela de login", "ok");

                }
                catch (Exception ex)
                {
                    DisplayAlert("Erro ao cadastrar!", ex.Message, "ok");
                }

            }
        }


        private async void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            
            insert();

            ClassBase cb = new ClassBase();

            Txt_email = entLoginCadastro.Text;

            try
            {
                if (entLoginCadastro.Text != null && entSenhaCadastro.Text != null)
                {
                    cb.disparoEmail(Txt_email);
                    await DisplayAlert("Conta criada com sucesso!", "confirmação enviada para seu e-mail de cadastro", "ok");
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Campos inválidos", "Tente novamente", "ok");
                }

               
            }
            catch(Exception ex)
            {
                await DisplayAlert("Erro no disparo de email", ex.Message, "ok");
            }



        }

        private async void btnVoltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}