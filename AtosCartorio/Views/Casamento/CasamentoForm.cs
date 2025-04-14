using AtosCartorio.Data;
using AtosCartorio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtosCartorio.Views
{
    public partial class CasamentoForm : Form
    {
        private readonly CartorioContext _context;
        private int? _registroId = null;

        // Construtor para novo registro
        public CasamentoForm()
        {
            InitializeComponent();
            _context = new CartorioContext();

            // Inicializar datas com o dia atual
            dtpDataRegistro.Value = DateTime.Now;
            dtpDataCasamento.Value = DateTime.Now;
            dtpDataNascimentoConjuge1.Value = DateTime.Now;
            dtpDataNascimentoPaiConjuge1.Checked = false;
            dtpDataNascimentoMaeConjuge1.Checked = false;
            dtpDataNascimentoConjuge2.Value = DateTime.Now;
            dtpDataNascimentoPaiConjuge2.Checked = false;
            dtpDataNascimentoMaeConjuge2.Checked = false;
            
            // Configurar o título do formulário
            this.Text = "Cadastro de Casamento";
            
            // Garantir que o formulário se ajusta corretamente ao seu conteúdo
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Padding = new Padding(25);
            
            // Adicionar eventos KeyPress para validar CPF (apenas números)
            txtCpfConjuge1.KeyPress += ValidarApenasNumeros;
            txtCpfPaiConjuge1.KeyPress += ValidarApenasNumeros;
            txtCpfMaeConjuge1.KeyPress += ValidarApenasNumeros;
            txtCpfConjuge2.KeyPress += ValidarApenasNumeros;
            txtCpfPaiConjuge2.KeyPress += ValidarApenasNumeros;
            txtCpfMaeConjuge2.KeyPress += ValidarApenasNumeros;
        }

        // Construtor para edição de registro existente
        public CasamentoForm(int id)
        {
            InitializeComponent();
            _context = new CartorioContext();
            _registroId = id;

            // Configurar o formulário
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Padding = new Padding(25);
            
            // Adicionar eventos KeyPress para validar CPF (apenas números)
            txtCpfConjuge1.KeyPress += ValidarApenasNumeros;
            txtCpfPaiConjuge1.KeyPress += ValidarApenasNumeros;
            txtCpfMaeConjuge1.KeyPress += ValidarApenasNumeros;
            txtCpfConjuge2.KeyPress += ValidarApenasNumeros;
            txtCpfPaiConjuge2.KeyPress += ValidarApenasNumeros;
            txtCpfMaeConjuge2.KeyPress += ValidarApenasNumeros;

            // Carregar o registro para edição
            CarregarRegistro(id);
        }

        private void CarregarRegistro(int id)
        {
            try
            {
                var casamento = _context.Casamentos.Find(id);

                if (casamento == null)
                {
                    MessageBox.Show("Registro não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Preencher os campos do formulário com os dados do registro
                dtpDataRegistro.Value = casamento.DataRegistro;
                dtpDataCasamento.Value = casamento.DataCasamento;

                // Preencher dados do Cônjuge 1
                if (casamento.Conjuge1 != null)
                {
                    txtNomeConjuge1.Text = casamento.Conjuge1.Nome;
                    dtpDataNascimentoConjuge1.Value = casamento.Conjuge1.DataNascimento;
                    txtCpfConjuge1.Text = casamento.Conjuge1.Cpf;
                    txtNomePaiConjuge1.Text = casamento.Conjuge1.NomePai;
                    txtNomeMaeConjuge1.Text = casamento.Conjuge1.NomeMae;
                    txtCpfPaiConjuge1.Text = casamento.Conjuge1.CpfPai;
                    txtCpfMaeConjuge1.Text = casamento.Conjuge1.CpfMae;

                    if (casamento.Conjuge1.DataNascimentoPai.HasValue)
                    {
                        dtpDataNascimentoPaiConjuge1.Value = casamento.Conjuge1.DataNascimentoPai.Value;
                        dtpDataNascimentoPaiConjuge1.Checked = true;
                    }
                    else
                    {
                        dtpDataNascimentoPaiConjuge1.Checked = false;
                    }

                    if (casamento.Conjuge1.DataNascimentoMae.HasValue)
                    {
                        dtpDataNascimentoMaeConjuge1.Value = casamento.Conjuge1.DataNascimentoMae.Value;
                        dtpDataNascimentoMaeConjuge1.Checked = true;
                    }
                    else
                    {
                        dtpDataNascimentoMaeConjuge1.Checked = false;
                    }
                }

                // Preencher dados do Cônjuge 2
                if (casamento.Conjuge2 != null)
                {
                    txtNomeConjuge2.Text = casamento.Conjuge2.Nome;
                    dtpDataNascimentoConjuge2.Value = casamento.Conjuge2.DataNascimento;
                    txtCpfConjuge2.Text = casamento.Conjuge2.Cpf;
                    txtNomePaiConjuge2.Text = casamento.Conjuge2.NomePai;
                    txtNomeMaeConjuge2.Text = casamento.Conjuge2.NomeMae;
                    txtCpfPaiConjuge2.Text = casamento.Conjuge2.CpfPai;
                    txtCpfMaeConjuge2.Text = casamento.Conjuge2.CpfMae;

                    if (casamento.Conjuge2.DataNascimentoPai.HasValue)
                    {
                        dtpDataNascimentoPaiConjuge2.Value = casamento.Conjuge2.DataNascimentoPai.Value;
                        dtpDataNascimentoPaiConjuge2.Checked = true;
                    }
                    else
                    {
                        dtpDataNascimentoPaiConjuge2.Checked = false;
                    }

                    if (casamento.Conjuge2.DataNascimentoMae.HasValue)
                    {
                        dtpDataNascimentoMaeConjuge2.Value = casamento.Conjuge2.DataNascimentoMae.Value;
                        dtpDataNascimentoMaeConjuge2.Checked = true;
                    }
                    else
                    {
                        dtpDataNascimentoMaeConjuge2.Checked = false;
                    }
                }

                // Alterar o título do formulário para indicar edição
                this.Text = "Editar Registro de Casamento";
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
            // Validar comprimento mínimo de 10 caracteres para campos de texto do Conjuge 1
            if (txtNomeConjuge1.Text.Trim().Length < 10)
            {
                MessageBox.Show("O nome do primeiro cônjuge deve ter pelo menos 10 caracteres.", 
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeConjuge1.Focus();
                return false;
            }
            
            if (txtNomePaiConjuge1.Text.Trim().Length < 10)
            {
                MessageBox.Show("O nome do pai do primeiro cônjuge deve ter pelo menos 10 caracteres.", 
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomePaiConjuge1.Focus();
                return false;
            }
            
            if (txtNomeMaeConjuge1.Text.Trim().Length < 10)
            {
                MessageBox.Show("O nome da mãe do primeiro cônjuge deve ter pelo menos 10 caracteres.", 
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeMaeConjuge1.Focus();
                return false;
            }
            
            // Validar comprimento mínimo de 10 caracteres para campos de texto do Conjuge 2
            if (txtNomeConjuge2.Text.Trim().Length < 10)
            {
                MessageBox.Show("O nome do segundo cônjuge deve ter pelo menos 10 caracteres.", 
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeConjuge2.Focus();
                return false;
            }
            
            if (txtNomePaiConjuge2.Text.Trim().Length < 10)
            {
                MessageBox.Show("O nome do pai do segundo cônjuge deve ter pelo menos 10 caracteres.", 
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomePaiConjuge2.Focus();
                return false;
            }
            
            if (txtNomeMaeConjuge2.Text.Trim().Length < 10)
            {
                MessageBox.Show("O nome da mãe do segundo cônjuge deve ter pelo menos 10 caracteres.", 
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeMaeConjuge2.Focus();
                return false;
            }
            
            return true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos antes de salvar
                if (!ValidarCamposTexto())
                {
                    return;
                }
                
                CasamentoModel casamento;

                // Verifica se é um novo registro ou atualização
                if (_registroId.HasValue)
                {
                    // Atualizar registro existente
                    casamento = _context.Casamentos.Find(_registroId.Value);

                    if (casamento == null)
                    {
                        MessageBox.Show("Registro não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    // Se o casamento existe mas os cônjuges são nulos, crie-os
                    if (casamento.Conjuge1 == null)
                        casamento.Conjuge1 = new ConjugeModel();
                        
                    if (casamento.Conjuge2 == null)
                        casamento.Conjuge2 = new ConjugeModel();
                }
                else
                {
                    // Criar novo registro
                    casamento = new CasamentoModel
                    {
                        Conjuge1 = new ConjugeModel(),
                        Conjuge2 = new ConjugeModel()
                    };
                }

                // Atualizar os dados do casamento
                casamento.DataRegistro = dtpDataRegistro.Value;
                casamento.DataCasamento = dtpDataCasamento.Value;

                // Atualizar dados do Cônjuge 1
                casamento.Conjuge1.Nome = txtNomeConjuge1.Text;
                casamento.Conjuge1.DataNascimento = dtpDataNascimentoConjuge1.Value;
                casamento.Conjuge1.Cpf = txtCpfConjuge1.Text;
                casamento.Conjuge1.NomePai = txtNomePaiConjuge1.Text;
                casamento.Conjuge1.NomeMae = txtNomeMaeConjuge1.Text;
                casamento.Conjuge1.CpfPai = txtCpfPaiConjuge1.Text;
                casamento.Conjuge1.CpfMae = txtCpfMaeConjuge1.Text;
                casamento.Conjuge1.DataNascimentoPai = dtpDataNascimentoPaiConjuge1.Checked ? dtpDataNascimentoPaiConjuge1.Value : null;
                casamento.Conjuge1.DataNascimentoMae = dtpDataNascimentoMaeConjuge1.Checked ? dtpDataNascimentoMaeConjuge1.Value : null;

                // Atualizar dados do Cônjuge 2
                casamento.Conjuge2.Nome = txtNomeConjuge2.Text;
                casamento.Conjuge2.DataNascimento = dtpDataNascimentoConjuge2.Value;
                casamento.Conjuge2.Cpf = txtCpfConjuge2.Text;
                casamento.Conjuge2.NomePai = txtNomePaiConjuge2.Text;
                casamento.Conjuge2.NomeMae = txtNomeMaeConjuge2.Text;
                casamento.Conjuge2.CpfPai = txtCpfPaiConjuge2.Text;
                casamento.Conjuge2.CpfMae = txtCpfMaeConjuge2.Text;
                casamento.Conjuge2.DataNascimentoPai = dtpDataNascimentoPaiConjuge2.Checked ? dtpDataNascimentoPaiConjuge2.Value : null;
                casamento.Conjuge2.DataNascimentoMae = dtpDataNascimentoMaeConjuge2.Checked ? dtpDataNascimentoMaeConjuge2.Value : null;

                if (!_registroId.HasValue)
                {
                    // Adicionar novo registro
                    _context.Casamentos.Add(casamento);
                }

                // Salvar alterações no banco de dados
                _context.SaveChanges();

                MessageBox.Show("Registro de casamento salvo com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparFormulario();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o registro: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Verificar se há dados preenchidos antes de fechar
            if (!string.IsNullOrWhiteSpace(txtNomeConjuge1.Text) || 
                !string.IsNullOrWhiteSpace(txtNomePaiConjuge1.Text) || 
                !string.IsNullOrWhiteSpace(txtNomeMaeConjuge1.Text) ||
                !string.IsNullOrWhiteSpace(txtNomeConjuge2.Text) || 
                !string.IsNullOrWhiteSpace(txtNomePaiConjuge2.Text) || 
                !string.IsNullOrWhiteSpace(txtNomeMaeConjuge2.Text))
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
            
            // Fechar o formulário
            this.Close();
        }

        private void LimparFormulario()
        {
            // Limpar campos do Conjuge 1
            txtNomeConjuge1.Clear();
            txtCpfConjuge1.Clear();
            txtNomePaiConjuge1.Clear();
            txtNomeMaeConjuge1.Clear();
            txtCpfPaiConjuge1.Clear();
            txtCpfMaeConjuge1.Clear();

            // Limpar campos do Conjuge 2
            txtNomeConjuge2.Clear();
            txtCpfConjuge2.Clear();
            txtNomePaiConjuge2.Clear();
            txtNomeMaeConjuge2.Clear();
            txtCpfPaiConjuge2.Clear();
            txtCpfMaeConjuge2.Clear();

            // Reinicializar datas
            dtpDataRegistro.Value = DateTime.Now;
            dtpDataCasamento.Value = DateTime.Now;
            dtpDataNascimentoConjuge1.Value = DateTime.Now;
            dtpDataNascimentoPaiConjuge1.Checked = false;
            dtpDataNascimentoMaeConjuge1.Checked = false;
            dtpDataNascimentoConjuge2.Value = DateTime.Now;
            dtpDataNascimentoPaiConjuge2.Checked = false;
            dtpDataNascimentoMaeConjuge2.Checked = false;
        }
    }
}
