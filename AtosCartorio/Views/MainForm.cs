using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AtosCartorio.Data;
using AtosCartorio.Views.Casamento;
using AtosCartorio.Views.Nascimento;
using AtosCartorio.Views.Obito;

namespace AtosCartorio.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;

            this.WindowState = FormWindowState.Maximized;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = $"Bem-vindo ao Sistema de Cartório - {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair do sistema?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void novoCasamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new CasamentoForm());
        }

        private void AbrirFormulario(Form formulario)
        {
            formulario.TopLevel = true;
            formulario.FormBorderStyle = FormBorderStyle.Sizable;
            formulario.MinimizeBox = true;
            formulario.MaximizeBox = false;
            formulario.ControlBox = true;
            formulario.StartPosition = FormStartPosition.CenterParent;

            Screen screen = Screen.FromControl(this);
            int maxWidth = screen.WorkingArea.Width - 350;
            int maxHeight = screen.WorkingArea.Height - 350;
            
            if (formulario is CasamentoForm)
            {
                if(screen.WorkingArea.Width > 2500)
                {
                    formulario.Width = Math.Min(990, maxWidth);
                    formulario.Height = Math.Min(530, maxHeight);
                }
                else
                {
                    formulario.Width = Math.Min(1850, maxWidth);
                    formulario.Height = Math.Min(970, maxHeight);
                }
                
            }
            else if (formulario is NascimentoForm || formulario is ObitoForm)
            {
                if (screen.WorkingArea.Width > 2500)
                {
                    formulario.Width = Math.Min(545, maxWidth);
                    formulario.Height = Math.Min(340, maxHeight);
                }
                else
                {
                    formulario.Width = Math.Min(1015, maxWidth);
                    formulario.Height = Math.Min(615, maxHeight);
                }
            }            
            else
            {
                if (screen.WorkingArea.Width > 2500)
                {
                    formulario.Width = Math.Min(965, maxWidth);
                    formulario.Height = Math.Min(610, maxHeight);
                }
                else
                {
                    formulario.Width = Math.Min(1870, maxWidth);
                    formulario.Height = Math.Min(1121, maxHeight);
                }
                
            }

            formulario.ShowDialog();

            toolStripStatusLabel.Text = $"Sistema de Cartório - {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
        }

        private void novoNascimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new NascimentoForm());
        }

        private void novoObitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ObitoForm());
        }

        private void atualizarBancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Esta operação irá atualizar a estrutura do banco de dados. Deseja continuar?",
                "Confirmação de Migration",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MigrationHelper.UpdateDatabase();
            }
        }
        
        private void recriarBancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "ATENÇÃO: Esta operação irá EXCLUIR e RECRIAR o banco de dados por completo.\n\n" +
                "TODOS OS DADOS SERÃO PERDIDOS!\n\n" +
                "Tem certeza que deseja continuar?",
                "ATENÇÃO - Perda de dados!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (MessageBox.Show(
                    "Esta é sua última chance de desistir.\n\n" +
                    "TODOS OS DADOS SERÃO APAGADOS PERMANENTEMENTE!\n\n" +
                    "Confirma que deseja recriar o banco de dados?",
                    "Confirmação Final",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    MigrationHelper.RecreateDatabase();
                    Cursor = Cursors.Default;
                }
            }
        }

        private void listagemCasamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ListaCasamento());
        }
        
        private void listagemNascimentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ListaNascimento());
        }
        
        private void listagemObitosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ListaObito());
        }
    }
}
