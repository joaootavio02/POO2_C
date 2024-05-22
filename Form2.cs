using System;
using System.Windows.Forms;

namespace Aula20240515Agenda
{
    public partial class Form2 : Form
    {
        private FormHome formHome;
        private Contato contato;

        public Form2(FormHome formHome, Contato contato = null)
        {
            InitializeComponent();
            this.formHome = formHome;
            this.contato = contato;

            if (contato != null)
            {
                // Preencher campos com dados do contato selecionado
                txtNome.Text = contato.Nome;
                txtTelefone.Text = contato.Telefone;
                // Adicione outros campos conforme necessário
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (contato == null)
            {
                // Adicionar novo contato
                Contato novoContato = new Contato()
                {
                    Nome = txtNome.Text,
                    Telefone = txtTelefone.Text
                    // Adicione outros campos conforme necessário
                };
                formHome.listaContatos.Add(novoContato);
            }
            else
            {
                // Editar contato existente
                contato.Nome = txtNome.Text;
                contato.Telefone = txtTelefone.Text;
                // Atualize outros campos conforme necessário
            }

            formHome.AtualizarGrid();
            this.Close();
        }
    }
}
