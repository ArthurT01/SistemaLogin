using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Situação_de_Aprendizagem_01
{
    public partial class frmNovoUsuario : Form
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataReader dr;
        string strSQL;

        public frmNovoUsuario()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            conexao = new MySqlConnection("Server = localhost; Database = agendacontatos; Uid = senai; Pwd = 1234 ");
            strSQL = "INSERT INTO usuarios (nome ,login , senha) VALUES (@nome, @login, @senha)";
            comando = new MySqlCommand(strSQL, conexao);


            try
            {
                if (txtNome.Text == "" || txtLogin.Text == "" || txtSenha.Text == "")
                {
                    MessageBox.Show("Dados incompletos!");
                }
                else
                {
                    comando.Parameters.AddWithValue("@nome", txtNome.Text);
                    comando.Parameters.AddWithValue("@login", txtLogin.Text);
                    comando.Parameters.AddWithValue("@senha", txtSenha.Text);

                    conexao.Open();

                    dr = comando.ExecuteReader();
                    MessageBox.Show("Usuário cadastrado com sucesso!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }           
        }
    }
}
