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
    public partial class frmNovoContato : Form
    {

        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataReader dr;
        string strSQL;

        public frmNovoContato()
        {
            InitializeComponent();
        }

        private void frmNovoContato_Load(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            conexao = new MySqlConnection("Server = localhost; Database = agendacontatos; Uid = senai; Pwd = 1234 ");
            strSQL = "INSERT INTO contatos (cpf ,nome ,telefone , email, cidade, estado) VALUES (@cpf, @nome, @telefone, @email, @cidade, @estado)";
            comando = new MySqlCommand(strSQL, conexao);

            
            try
            {
                if (!mktCpf.MaskCompleted || !mktTelefone.MaskCompleted || txtNome.Text == "" || txtEstado.Text == "" || txtEmail.Text == "" || txtCidade.Text == "")
                {
                    MessageBox.Show("Dados incompletos!");
                }
                else
                {
                    if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                    {
                        MessageBox.Show("Dados incorretos!");
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@cpf", mktCpf.Text);
                        comando.Parameters.AddWithValue("@nome", txtNome.Text);
                        comando.Parameters.AddWithValue("@telefone", mktTelefone.Text);
                        comando.Parameters.AddWithValue("@email", txtEmail.Text);
                        comando.Parameters.AddWithValue("@cidade", txtCidade.Text);
                        comando.Parameters.AddWithValue("@estado", txtEstado.Text);

                        conexao.Open();

                        comando.ExecuteNonQuery();

                        MessageBox.Show("Contato salvo com sucesso!");
                        chkCadastrar.Checked = false;
                    }
                }            
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            conexao = new MySqlConnection("Server = localhost; Database = agendacontatos; Uid = senai; Pwd = 1234 ");
            strSQL = "SELECT * FROM contatos";
            comando = new MySqlCommand(strSQL, conexao);

            comando.Parameters.AddWithValue("@cpf", mktCpf.Text);
            
            conexao.Open();

            dr = comando.ExecuteReader();

            
            if(dr.HasRows)
            {
                
                while(dr.Read())
                {
                    mktCpf.Text = Convert.ToString(dr["cpf"]);
                    txtNome.Text = Convert.ToString(dr["nome"]);
                    mktTelefone.Text = Convert.ToString(dr["telefone"]);
                    txtEmail.Text = Convert.ToString(dr["email"]);
                    txtCidade.Text = Convert.ToString(dr["cidade"]);
                    txtEstado.Text = Convert.ToString(dr["estado"]);

                    block();
                }
            }
            else
            {
                MessageBox.Show("Contato não encontrado!");
            }
            conexao.Close();

        }

        private void chkCadastrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCadastrar.Checked == true)
            {
                desblock();
            }
            else
            {
                block();
            }
        }

        private void block()//DEIXA OS CAMPOS BLOQUEADOS PARA O PREENCHIMENTO
        {
            mktCpf.ReadOnly = true;
            txtNome.ReadOnly = true;
            mktTelefone.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtCidade.ReadOnly = true;
            txtEstado.ReadOnly = true;
        }


        private void desblock()//DEIXA OS CAMPOS LIVRES PARA O PREENCHIMENTO
        {
            mktCpf.ReadOnly = false;
            txtNome.ReadOnly = false;
            mktTelefone.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtCidade.ReadOnly = false;
            txtEstado.ReadOnly = false;

            limpa();

        }

        private void limpa()//LIMPA TODOS OS CAMPOS
        {
            mktCpf.Text = "";
            txtNome.Text = "";
            mktTelefone.Text = "";
            txtEmail.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
        }
    }
}
