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

namespace AtosCartorio.Views.Obito
{
    public partial class ListaObito : Form
    {
        private readonly CartorioContext _context;
        private readonly ObitoRepository _obitoRepository;

        public ListaObito()
        {
            InitializeComponent();
            _context = new CartorioContext();
            _obitoRepository = new ObitoRepository();

            this.Shown += ListaObito_Shown;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvObitos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um registro para excluir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Deseja realmente excluir este registro de óbito?",
                "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dgvObitos.SelectedRows[0].Cells["Id"].Value);

                    var obito = _context.Obitos.Find(id);

                    if (obito != null)
                    {
                        _context.Obitos.Remove(obito);
                        _context.SaveChanges();

                        CarregarObitos();
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
                if (dgvObitos.Rows.Count == 0)
                {
                    MessageBox.Show("Não há dados para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Arquivo XML (*.xml)|*.xml|Arquivo CSV (*.csv)|*.csv|Arquivo Excel (*.xlsx)|*.xlsx|Todos os arquivos (*.*)|*.*";
                    saveDialog.Title = "Exportar Dados";
                    saveDialog.DefaultExt = "xml";
                    saveDialog.FileName = "Obitos_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

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
                    for (int i = 0; i < dgvObitos.Columns.Count; i++)
                    {
                        headers += dgvObitos.Columns[i].HeaderText;
                        if (i < dgvObitos.Columns.Count - 1)
                            headers += ";";
                    }
                    sw.WriteLine(headers);

                    foreach (DataGridViewRow row in dgvObitos.Rows)
                    {
                        string line = string.Empty;
                        for (int i = 0; i < dgvObitos.Columns.Count; i++)
                        {
                            object cellValue = row.Cells[i].Value;
                            line += cellValue != null ? cellValue.ToString() : "";

                            if (i < dgvObitos.Columns.Count - 1)
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
                var obitos = (List<ObitoModel>)dgvObitos.DataSource;

                XmlSerializer serializer = new XmlSerializer(typeof(List<ObitoModel>));

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

                    serializer.Serialize(writer, obitos, ns);
                }

                MessageBox.Show($"Dados exportados com sucesso para {filePath}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao exportar para XML: {ex.Message}", ex);
            }
        }

        private void ListaObito_Load(object sender, EventArgs e)
        {
            CarregarObitos();
            dgvObitos.CellDoubleClick += DgvObitos_CellDoubleClick;
        }

        private void ListaObito_Shown(object sender, EventArgs e)
        {
            CarregarObitos();
        }

        private void DgvObitos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int id = Convert.ToInt32(dgvObitos.Rows[e.RowIndex].Cells["Id"].Value);

            var formObito = new ObitoForm(id);

            formObito.StartPosition = FormStartPosition.CenterScreen;

            this.Hide();

            if (formObito.ShowDialog() == DialogResult.OK)
            {
                CarregarObitos();
                this.Show();
            }
            else
            {
                this.Close();
            }
        }

        private void CarregarObitos()
        {
            try
            {
                _context.ChangeTracker.Clear();

                List<ObitoModel> obitos = _obitoRepository.GetAll(forceReload: true);

                var obitosView = obitos.Select(o => new ObituarioView
                {
                    Id = o.Id,
                    NomeFalecido = o.NomeFalecido ?? "Não informado",
                    DataFalecimento = o.DataFalecimento,
                    DataRegistro = o.DataRegistro,
                    ModeloOriginal = o,
                    DataNascimento = o.DataNascimento,
                    NomeMae = o.NomeMae ?? "Não informado",
                    NomePai = o.NomePai ?? "Não informado"  

                }).ToList();

                dgvObitos.DataSource = null;
                dgvObitos.DataSource = obitosView;

                ConfigurarColunas();

                if (obitos.Count == 0)
                {
                    MessageBox.Show("Não foram encontrados registros de óbitos.",
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
            dgvObitos.AutoGenerateColumns = false;
            dgvObitos.Columns.Clear();

            dgvObitos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "Id",
                Width = 50
            });

            dgvObitos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NomeFalecido",
                HeaderText = "Nome",
                Width = 250
            });

            dgvObitos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataFalecimento",
                HeaderText = "Falecimento",
                Width = 250,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });

            dgvObitos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataNascimento",
                HeaderText = "Nascimento",
                Width = 250,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });

            dgvObitos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NomePai",
                HeaderText = "Pai",
                Width = 250
            });

            dgvObitos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NomeMae",
                HeaderText = "Mãe",
                Width = 250
            });

            dgvObitos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataRegistro",
                HeaderText = "Data Registro",
                Width = 250,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });

            dgvObitos.AllowUserToAddRows = false;
            dgvObitos.AllowUserToDeleteRows = false;
            dgvObitos.ReadOnly = true;
            dgvObitos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvObitos.MultiSelect = false;
            dgvObitos.RowHeadersVisible = false;
            dgvObitos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvObitos.AllowUserToResizeRows = false;

            dgvObitos.RowTemplate.Height = 37;
        }

    }
}
