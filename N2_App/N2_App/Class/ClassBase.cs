using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static N2_App.Class.Conexao;
using System.Net;
using System.Net.Mail;


namespace N2_App.Class
{

    internal class ClassBase
    {

        Conexao conexaoTeste = new Conexao();

        private NpgsqlConnection conect;
        private string sql2;
        private NpgsqlCommand cmd2;
        private DataTable dt;
        private NpgsqlDataReader dr;

        //Atributos abaixo para login
        public bool tem = false;
        public string msg = ""; //tudo ok enquanto vázio.

        //Atributos abaixo para disparo de email
        public string passMail;
        public string mail;

        public void Insert(string Txt_email, string Txt_senha)
        {

            conect = new NpgsqlConnection(conexaoTeste.ConectionString());

            try
            {

                conect.Open();
                sql2 = $"INSERT INTO tbl_UsuarioDb2 (Email, Senha)" + $"VALUES('{Txt_email}','{Txt_senha}')";
                
                //sql = "INSERT INTO tbl_UsuarioDb (Email, Senha, ConfirmarSenha, Data_Cadastro) VALUES (@Txt_email, @Txt_senha, @Txt_confirmarSenha, GETDATE())";
                cmd2 = new NpgsqlCommand(sql2, conect);

                dt = new DataTable();
                dt.Load(cmd2.ExecuteReader());

                conect.Close();


            }
            catch (Exception ex)
            {          
                Console.WriteLine("Erro de inserção: " + ex.Message);
            }
            

        }


        public bool verificarLogin(string Txt_email, string Txt_senha)
        {
                 
                conect = new NpgsqlConnection(conexaoTeste.ConectionString());

                try
                {
                    
                    conect.Open();
                    sql2 = "SELECT * FROM tbl_UsuarioDb2 WHERE email = '@txt_email' AND senha = '@txt_senha'";
                    cmd2.Parameters.AddWithValue("@txt_email", Txt_email);
                    cmd2.Parameters.AddWithValue("@txt_senha", Txt_senha);

                    cmd2 = new NpgsqlCommand(sql2, conect);

                    dt = new DataTable();
                    dr = cmd2.ExecuteReader();

                    
                    if (dr.HasRows) //Se encontrou o email e senha
                    {
                        tem = true;
                        Console.WriteLine("Credênciais encontradas!");
                    }

                else
                {
                    Console.WriteLine("Credênciais NÃO encontradas!");
                }

                    //conect.Close();

                }

                catch (Exception ex)
                {
                    Console.WriteLine("Erro no banco de dados: " + ex.Message);
                    this.msg = "Erro no banco de dados!";
                }


            return tem;

        }



            public void disparoEmail(string email)
            {

                    try
                    {
                        string from = "apicep@outlook.com";
                        string to = email;

                        MailMessage msg = new MailMessage(from, to);

                        SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                        client.EnableSsl = true;                      
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential("apicep@outlook.com", "senhadaconta12345");

                        msg.BodyEncoding = Encoding.GetEncoding("UTF-8"); // Configuração do body HTML em UTF-8 
                        msg.SubjectEncoding = Encoding.GetEncoding("UTF-8"); // Configuração do titulo em UTF-8
                        msg.Body = "Email cadastrado na base de dados e conta criada com sucesso!";
                        msg.Subject = "Cadastro de conta";
                        msg.IsBodyHtml = true;
 
                        client.Send(msg); //enviando

                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message); 

                    }

                    Console.WriteLine("enviado");

                }

      
            }

}
