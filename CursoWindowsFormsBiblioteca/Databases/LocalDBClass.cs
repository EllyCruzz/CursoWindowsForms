﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CursoWindowsFormsBiblioteca.Databases
{
    public class LocalDBClass
    {
        public string StringConn;
        public SqlConnection ConnDB;

        public LocalDBClass() 
        {
            try
            {
                //faz a string de conexao
                StringConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Databases\\Fichario.mdf;Integrated Security=True";
                //faz a conexão
                ConnDB = new SqlConnection(StringConn);
                //abre a conexão
                ConnDB.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        //retorna dados, uso isso pra fazer uma consulta ao banco de dados SELECT
        public DataTable SQLQuery(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                //prepara um pacote(comando + conexao) pra ser enviado pro banco
                var myCommand = new SqlCommand(sql, ConnDB);
                //define o timeout como 0 ou seja todo tempo necessário pra executar
                myCommand.CommandTimeout = 0;
                //lê o comando
                var reader = myCommand.ExecuteReader();
                //pega o resultado que deu no reader e transforma em Tabela de memória(DataTable)
                dt.Load(reader);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }
        //caso eu queira executar um comando do banco de dados UPDATE, DELETE ou INSERT
        public string SQLCommand(string sql)
        {
            try
            {
                //prepara um pacote(comando + conexao) pra ser enviado pro banco
                var myCommand = new SqlCommand(sql, ConnDB);
                //define o timeout como 0 ou seja todo tempo necessário pra executar
                myCommand.CommandTimeout = 0;
                //lê o comando
                var reader = myCommand.ExecuteReader();
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }
        //fechar a conexão
        public void CloseConn()
        {
            ConnDB.Close();
        }

    }
}
