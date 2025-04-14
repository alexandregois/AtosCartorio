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
    public partial class ObitoForm : Form
    {
        private readonly CartorioContext _context;
        private int? _registroId = null;

        public ObitoForm()
        {
            InitializeComponent();
            _context = new CartorioContext();
            
            // Inicializar datas com o dia atual
            dtpDataRegistro.Value = DateTime.Now;
            dtpDataObito.Value = DateTime.Now;
            dtpDataNascimento.Value = DateTime.Now;
            dtpDataNascimentoPai.Checked = false;
            dtpDataNascimentoMae.Checked = false;
        }
        
        // Construtor para edição de registro existente
        public ObitoForm(int id)
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
                var obito = _context.Obitos.Find(id);

                if (obito == null)
                {
                    MessageBox.Show("Registro não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Preencher os campos do formulário com os dados do registro
                txtNomeFalecido.Text = obito.NomeFalecido;
                dtpDataObito.Value = obito.DataFalecimento;
                dtpDataNascimento.Value = obito.DataNascimento;
                txtNomePai.Text = obito.NomePai;
                txtNomeMae.Text = obito.NomeMae;
                dtpDataRegistro.Value = obito.DataRegistro;
                
                // Configurar data de nascimento do pai
                if (obito.DataNascimentoPai.HasValue)
                {
                    dtpDataNascimentoPai.Value = obito.DataNascimentoPai.Value;
                    dtpDataNascimentoPai.Checked = true;
                }
                else
                {
                    dtpDataNascimentoPai.Checked = false;
                }

                // Configurar data de nascimento da mãe
                if (obito.DataNascimentoMae.HasValue)
                {
                    dtpDataNascimentoMae.Value = obito.DataNascimentoMae.Value;
                    dtpDataNascimentoMae.Checked = true;
                }
                else
                {
                    dtpDataNascimentoMae.Checked = false;
                }

                // Alterar o título do formulário para indicar edição
                this.Text = "Editar Registro de Óbito";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o registro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        
        private bool ValidarCamposTexto()
        {
            // Validar comprimento mínimo de 10 caracteres para campos de texto
            if (txtNomeFalecido.Text.Trim().Length < 10)
            {
                MessageBox.Show("O nome do falecido deve ter pelo menos 10 caracteres.", 
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeFalecido.Focus();
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
                // Validar campos antes de salvar
                if (!ValidarCamposTexto())
                {
                    return;
                }

                ObitoModel obito;

                // Verifica se é um novo registro ou atualização
                if (_registroId.HasValue)
                {
                    // Atualizar registro existente
                    obito = _context.Obitos.Find(_registroId.Value);

                    if (obito == null)
                    {
                        MessageBox.Show("Registro não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    // Criar novo registro
                    obito = new ObitoModel();
                }
                
                // Atualizar os dados do objeto com valores do formulário
                obito.DataRegistro = dtpDataRegistro.Value;
                obito.DataFalecimento = dtpDataObito.Value;
                obito.NomeFalecido = txtNomeFalecido.Text;
                obito.DataNascimento = dtpDataNascimento.Value;
                obito.NomePai = txtNomePai.Text;
                obito.NomeMae = txtNomeMae.Text;
                obito.DataNascimentoPai = dtpDataNascimentoPai.Checked ? dtpDataNascimentoPai.Value : (DateTime?)null;
                obito.DataNascimentoMae = dtpDataNascimentoMae.Checked ? dtpDataNascimentoMae.Value : (DateTime?)null;

                if (!_registroId.HasValue)
                {
                    // Adicionar novo registro
                    _context.Obitos.Add(obito);
                }

                // Salvar alterações no banco de dados
                _context.SaveChanges();

                MessageBox.Show("Registro de óbito salvo com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            if (!string.IsNullOrWhiteSpace(txtNomeFalecido.Text) || 
                !string.IsNullOrWhiteSpace(txtNomePai.Text) || 
                !string.IsNullOrWhiteSpace(txtNomeMae.Text))
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
            // Limpar campos de texto
            txtNomeFalecido.Clear();
            txtNomePai.Clear();
            txtNomeMae.Clear();

            // Reinicializar datas
            dtpDataRegistro.Value = DateTime.Now;
            dtpDataObito.Value = DateTime.Now;
            dtpDataNascimento.Value = DateTime.Now;
            dtpDataNascimentoPai.Checked = false;
            dtpDataNascimentoMae.Checked = false;
        }
    }
}
