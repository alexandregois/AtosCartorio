using System;
using System.Windows.Forms;
using AtosCartorio.Repositories;
using AtosCartorio.Models;
using AtosCartorio.Data;
using System.Linq;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace AtosCartorio.Views.Nascimento
{
    public partial class ListaNascimento : Form
    {
        private readonly CartorioContext _context;
        private readonly NascimentoRepository _nascimentoRepository;

        public ListaNascimento()
        {
            InitializeComponent();
            _context = new CartorioContext();
            _nascimentoRepository = new NascimentoRepository();

            this.Shown += ListaNascimento_Shown;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvNascimentos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um registro para excluir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Deseja realmente excluir este registro de nascimento?",
                "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dgvNascimentos.SelectedRows[0].Cells["Id"].Value);

                    var nascimento = _context.Nascimentos.Find(id);

                    if (nascimento != null)
                    {
                        _context.Nascimentos.Remove(nascimento);
                        _context.SaveChanges();

                        CarregarNascimentos();
                        MessageBox.Show("Registro excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir o registro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNascimentos.Rows.Count == 0)
                {
                    MessageBox.Show("Não há dados para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Arquivo XML (*.xml)|*.xml|Arquivo CSV (*.csv)|*.csv|Arquivo Excel (*.xlsx)|*.xlsx|Todos os arquivos (*.*)|*.*";
                    saveDialog.Title = "Exportar Dados";
                    saveDialog.DefaultExt = "xml";
                    saveDialog.FileName = "Nascimentos_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveDialog.FileName;
                        string extension = Path.GetExtension(filePath).ToLower();

                        if (extension == ".xml")
                        {
                            ExportarParaXML(filePath);
                        }
                        else if (extension == ".csv")
                        {
                            ExportarParaCSV(filePath);
                        }
                        else if (extension == ".xlsx")
                        {
                            MessageBox.Show("Exportação para Excel não implementada. Use XML ou CSV.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Formato de arquivo não suportado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar os dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarParaCSV(string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
                {
                    string headers = string.Empty;
                    for (int i = 0; i < dgvNascimentos.Columns.Count; i++)
                    {
                        headers += dgvNascimentos.Columns[i].HeaderText;
                        if (i < dgvNascimentos.Columns.Count - 1)
                            headers += ";";
                    }
                    sw.WriteLine(headers);

                    foreach (DataGridViewRow row in dgvNascimentos.Rows)
                    {
                        string line = string.Empty;
                        for (int i = 0; i < dgvNascimentos.Columns.Count; i++)
                        {
                            object cellValue = row.Cells[i].Value;
                            line += cellValue != null ? cellValue.ToString() : "";

                            if (i < dgvNascimentos.Columns.Count - 1)
                                line += ";";
                        }
                        sw.WriteLine(line);
                    }
                }

                MessageBox.Show($"Dados exportados com sucesso para {filePath}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao exportar para CSV: {ex.Message}");
            }
        }

        private void ExportarParaXML(string filePath)
        {
            try
            {
                var nascimentos = (List<NascimentoModel>)dgvNascimentos.DataSource;

                XmlSerializer serializer = new XmlSerializer(typeof(List<NascimentoModel>));

                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "  ",
                    NewLineChars = "\r\n",
                    NewLineHandling = NewLineHandling.Replace,
                    Encoding = System.Text.Encoding.UTF8
                };

                using (XmlWriter writer = XmlWriter.Create(filePath, settings))
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");

                    serializer.Serialize(writer, nascimentos, ns);
                }

                MessageBox.Show($"Dados exportados com sucesso para {filePath}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao exportar para XML: {ex.Message}", ex);
            }
        }

        private void ListaNascimento_Load(object sender, EventArgs e)
        {
            CarregarNascimentos();
            dgvNascimentos.CellDoubleClick += DgvNascimentos_CellDoubleClick;
        }

        private void ListaNascimento_Shown(object sender, EventArgs e)
        {
            CarregarNascimentos();
        }

        private void DgvNascimentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int id = Convert.ToInt32(dgvNascimentos.Rows[e.RowIndex].Cells["Id"].Value);

            var formNascimento = new NascimentoForm(id);

            formNascimento.StartPosition = FormStartPosition.CenterScreen;

            this.Hide();

            if (formNascimento.ShowDialog() == DialogResult.OK)
            {
                CarregarNascimentos();
                this.Show();
            }
            else
            {
                this.Close();
            }
        }

        private void CarregarNascimentos()
        {
            try
            {
                _context.ChangeTracker.Clear();

                List<NascimentoModel> nascimentos = _nascimentoRepository.GetAll(forceReload: true);

                var nascimentosView = nascimentos.Select(n => new NascimentoView
                {
                    Id = n.Id,
                    NomeRegistrado = n.NomeCompleto ?? "Não informado",
                    NomeMae = n.NomeMae ?? "Não informado",
                    NomePai = n.NomePai ?? "Não informado",
                    DataNascimento = n.DataNascimento,
                    DataNascimentoMae = n.DataNascimentoMae,
                    DataNascimentoPai = n.DataNascimentoPai,
                    CpfMae = n.CpfMae,
                    CpfPai = n.CpfPai,
                    DataRegistro = n.DataRegistro,
                    ModeloOriginal = n

                }).ToList();

                dgvNascimentos.DataSource = null;
                dgvNascimentos.DataSource = nascimentosView;

                ConfigurarColunas();

                if (nascimentos.Count == 0)
                {
                    MessageBox.Show("Não foram encontrados registros de nascimentos.",
                        "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os dados: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColunas()
        {
            dgvNascimentos.AutoGenerateColumns = false;
            dgvNascimentos.Columns.Clear();

            dgvNascimentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "Id",
                Width = 50
            });

            dgvNascimentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NomeCompleto",
                HeaderText = "Nome",
                Width = 250
            });

            dgvNascimentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataNascimento",
                HeaderText = "Nascimento",
                Width = 150,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });

            dgvNascimentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NomePai",
                HeaderText = "Pai",
                Width = 250
            });

            dgvNascimentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataNascimentoPai",
                HeaderText = "Nasc. Pai",
                Width = 150,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });

            dgvNascimentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NomeMae",
                HeaderText = "Mãe",
                Width = 250
            });

            dgvNascimentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataNascimentoMae",
                HeaderText = "Nasc. Mãe",
                Width = 150,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });

            dgvNascimentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataRegistro",
                HeaderText = "Registro",
                Width = 150,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });

            dgvNascimentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CpfPai",
                HeaderText = "CPF Pai",
                Width = 120
            });

            dgvNascimentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CpfMae",
                HeaderText = "CPF Mãe",
                Width = 120
            });

            dgvNascimentos.AllowUserToAddRows = false;
            dgvNascimentos.AllowUserToDeleteRows = false;
            dgvNascimentos.ReadOnly = true;
            dgvNascimentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNascimentos.MultiSelect = false;
            dgvNascimentos.RowHeadersVisible = false;
            dgvNascimentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvNascimentos.AllowUserToResizeRows = false;

            dgvNascimentos.RowTemplate.Height = 37;
        }
    }
}
