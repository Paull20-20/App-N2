using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace N2_App.Class
{
    internal class Conexao
    {

        //NpgsqlConnection cmd = new NpgsqlConnection();
        
        static string host = "ec2-44-196-174-238.compute-1.amazonaws.com";
        static string database = "den039trafl2e3";
        static string user = "hjwejqyagzdpor";
        static string port = "5432";
        static string password = "fc56f05a3e617951cc71a610ef84ee2c96633839c7dde4ed4bac5cde2a951996";

        string conexao = $"server={host};db={database};userId={user};port={port};password={password}";


        public string ConectionString()
        {
            return conexao;
        }



    }


}
