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
    public partial class frmOpcoes : Form
    {
        public frmOpcoes()
        {
            InitializeComponent();
        }

        private void btnNovoContato_Click(object sender, EventArgs e)
        {
            frmNovoContato frmNovoContato = new frmNovoContato();
            frmNovoContato.ShowDialog();
        }

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            frmNovoUsuario frmNovoUsuario = new frmNovoUsuario();
            frmNovoUsuario.ShowDialog();
        }

        private void btnVizualizacao_Click(object sender, EventArgs e)
        {
            frmVizualizacaoDeUsuario frmVizualizacao = new frmVizualizacaoDeUsuario();
            frmVizualizacao.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
