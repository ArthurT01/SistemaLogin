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
    public partial class frmVizualizacaoDeUsuario : Form
    {
        MySqlConnection conexao;
        MySqlDataAdapter da;
        string strSQL;

        public frmVizualizacaoDeUsuario()
        {
            InitializeComponent();
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server = localhost; Database = agendacontatos; Uid = senai; Pwd = 1234 ");
                strSQL = "SELECT * FROM contatos";

                da = new MySqlDataAdapter(strSQL, conexao);

                conexao.Open();

                DataTable dt = new DataTable();

                da.Fill(dt);

                dtgDados.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
