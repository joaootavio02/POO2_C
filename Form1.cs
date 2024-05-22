using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula20240515Agenda
{
    public partial class FormHome : Form
    {
        public List<Contato> listaContatos;
        public Contato selecionado;

        public FormHome()
        {
            InitializeComponent();
            listaContatos = new List<Contato>();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (selecionado != null)
            {
                listaContatos.Remove(selecionado);
                AtualizarGrid();
                selecionado = null;
            }
            else
            {
                MessageBox.Show("Selecione um contato para remover.");
            }
        }

        private void dgvContatos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selecionado = listaContatos[e.RowIndex];
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (selecionado != null)
            {
                Form2 form2 = new Form2(this, selecionado);
                form2.Show();
            }
            else
            {
                MessageBox.Show("Selecione um contato para editar.");
            }
        }

        public void AtualizarGrid()
        {
            dgvContatos.DataSource = null;
            dgvContatos.DataSource = listaContatos;
            dgvContatos.Refresh();
        }
    }
}
