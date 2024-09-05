using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Situação_de_Aprendizagem_01


{
    public partial class frmLogin : Form
    {

        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataReader dr;
        string strSQL;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server = localhost; Database = agendacontatos; Uid = senai; Pwd = 1234");
                strSQL = "SELECT codigo FROM usuarios WHERE login = @login AND senha = @senha";

                comando = new MySqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@login", txtLogin.Text);
                comando.Parameters.AddWithValue("@senha", txtSenha.Text);

                conexao.Open();

                dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtLogin.Text = "";
                        txtSenha.Text = "";
                        frmOpcoes Menu = new frmOpcoes();
                        Menu.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Senha ou Login de usuário incorreto ou inexistênte");
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

        private void chkExibirSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (txtSenha.Text != "Digite sua senha")
            {
                if (chkExibirSenha.Checked)
                {
                    txtSenha.PasswordChar = default;
                }
                else
                {
                    txtSenha.PasswordChar = '*';
                }
            }
        }
    }
}
