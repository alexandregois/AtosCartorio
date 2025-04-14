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
using AtosCartorio.Models;

namespace AtosCartorio.Views
{
    public partial class NascimentoForm : Form
    {
        private readonly CartorioContext _context;
        private int? _registroId = null;

        // Construtor para novo registro
        public NascimentoForm()
        {
            InitializeComponent();
            _context = new CartorioContext();

            // Inicializar datas com o dia atual
            dtpDataRegistro.Value = DateTime.Now;
            dtpDataNascimento.Value = DateTime.Now;
            dtpDataNascimentoPai.Checked = false;
            dtpDataNascimentoMae.Checked = false;

            // Adicionar eventos KeyPress para validar CPF (apenas números)
            txtCpfPai.KeyPress += ValidarApenasNumeros;
            txtCpfMae.KeyPress += ValidarApenasNumeros;
        }

        // Construtor para edição de registro existente
        public NascimentoForm(int id)
        {
            InitializeComponent();
            _context = new CartorioContext();
            _registroId = id;

            // Carregar o registro para edição
            CarregarRegistro(id);
        }

        private void CarregarRegistro(int id)
        {
            try
            {
                var nascimento = _context.Nascimentos.Find(id);

                if (nascimento == null)
                {
                    MessageBox.Show("Registro não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Preencher os campos do formulário com os dados do registro
                txtNomeRegistrado.Text = nascimento.NomeCompleto;
                dtpDataNascimento.Value = nascimento.DataNascimento;
                txtNomePai.Text = nascimento.NomePai;

                // Configurar data de nascimento do pai (sem o operador ??)
                dtpDataNascimentoPai.Value = nascimento.DataNascimentoPai.Value;
                dtpDataNascimentoPai.Checked = true;  // Se você deseja que o DateTimePicker esteja marcado

                txtNomeMae.Text = nascimento.NomeMae;

                // Configurar data de nascimento da mãe (sem o operador ??)
                dtpDataNascimentoMae.Value = nascimento.DataNascimentoMae.Value;
                dtpDataNascimentoMae.Checked = true;  // Se você deseja que o DateTimePicker esteja marcado

                dtpDataRegistro.Value = nascimento.DataRegistro;
                txtCpfPai.Text = nascimento.CpfPai;
                txtCpfMae.Text = nascimento.CpfMae;

                // Alterar o título do formulário para indicar edição
                this.Text = "Editar Registro de Nascimento";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o registro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void ValidarApenasNumeros(object sender, KeyPressEventArgs e)
        {
            // Permite apenas números e teclas de controle (como backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita apenas números.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool ValidarCamposTexto()
        {
            // Validar comprimento mínimo de 10 caracteres para campos de texto
            if (txtNomeRegistrado.Text.Trim().Length < 10)
            {
                MessageBox.Show("O nome do registrado deve ter pelo menos 10 caracteres.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeRegistrado.Focus();
                return false;
            }

            if (txtNomePai.Text.Trim().Length < 10)
            {
                MessageBox.Show("O nome do pai deve ter pelo menos 10 caracteres.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomePai.Focus();
                return false;
            }

            if (txtNomeMae.Text.Trim().Length < 10)
            {
                MessageBox.Show("O nome da mãe deve ter pelo menos 10 caracteres.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeMae.Focus();
                return false;
            }

            return true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar os campos do formulário antes de salvar
                if (!ValidarCamposTexto())
                {
                    return;
                }

                Models.NascimentoModel nascimento;

                // Verifica se é um novo registro ou atualização
                if (_registroId.HasValue)
                {
                    // Atualizar registro existente
                    nascimento = _context.Nascimentos.Find(_registroId.Value);

                    if (nascimento == null)
                    {
                        MessageBox.Show("Registro não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    // Criar novo registro
                    nascimento = new Models.NascimentoModel();
                }

                // Atualizar os dados do objeto com valores do formulário
                nascimento.NomeCompleto = txtNomeRegistrado.Text;
                nascimento.DataNascimento = dtpDataNascimento.Value;
                nascimento.NomePai = txtNomePai.Text;
                nascimento.DataNascimentoPai = dtpDataNascimentoPai.Checked ? dtpDataNascimentoPai.Value : DateTime.Now;
                nascimento.NomeMae = txtNomeMae.Text;
                nascimento.DataNascimentoMae = dtpDataNascimentoMae.Checked ? dtpDataNascimentoMae.Value : DateTime.Now;
                nascimento.DataRegistro = dtpDataRegistro.Value;
                nascimento.CpfPai = txtCpfPai.Text;
                nascimento.CpfMae = txtCpfMae.Text;

                if (!_registroId.HasValue)
                {
                    // Adicionar novo registro
                    _context.Nascimentos.Add(nascimento);
                }

                // Salvar alterações no banco de dados
                _context.SaveChanges();

                MessageBox.Show("Registro de nascimento salvo com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparFormulario();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o registro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Verificar se há dados preenchidos antes de fechar
            if (!string.IsNullOrWhiteSpace(txtNomeRegistrado.Text) ||
                !string.IsNullOrWhiteSpace(txtNomePai.Text) ||
                !string.IsNullOrWhiteSpace(txtNomeMae.Text) ||
                !string.IsNullOrWhiteSpace(txtCpfPai.Text) ||
                !string.IsNullOrWhiteSpace(txtCpfMae.Text))
            {
                DialogResult result = MessageBox.Show(
                    "Deseja realmente cancelar? Os dados preenchidos serão perdidos.",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LimparFormulario()
        {
            // Limpar campos de texto
            txtNomeRegistrado.Clear();
            txtNomePai.Clear();
            txtNomeMae.Clear();
            txtCpfPai.Clear();
            txtCpfMae.Clear();

            // Reinicializar datas
            dtpDataRegistro.Value = DateTime.Now;
            dtpDataNascimento.Value = DateTime.Now;
            dtpDataNascimentoPai.Checked = false;
            dtpDataNascimentoMae.Checked = false;
        }
    }
}
