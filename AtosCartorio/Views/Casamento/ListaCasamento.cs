using System;
using System.Windows.Forms;
using AtosCartorio.Repositories;
using AtosCartorio.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AtosCartorio.Data;

namespace AtosCartorio.Views.Casamento
{    
   
    public partial class ListaCasamento : Form
    {
        private readonly CasamentoRepository _casamentoRepository;
        private readonly CartorioContext _context;

        public ListaCasamento()
        {
            InitializeComponent();
            _context = new CartorioContext();

            _casamentoRepository = new CasamentoRepository();

            this.Shown += ListaCasamento_Shown;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvCasamentos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um registro para excluir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Deseja realmente excluir este registro de casamento?",
                "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dgvCasamentos.SelectedRows[0].Cells["Id"].Value);

                    var casamento = _context.Casamentos.Find(id);

                    if (casamento != null)
                    {
                        _context.Casamentos.Remove(casamento);
                        _context.SaveChanges();

                        CarregarCasamentos();
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
                // Verificar se há dados para exportar
                if (dgvCasamentos.Rows.Count == 0)
                {
                    MessageBox.Show("Não há dados para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Configurar o SaveFileDialog
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Arquivo XML (*.xml)|*.xml|Arquivo CSV (*.csv)|*.csv|Arquivo Excel (*.xlsx)|*.xlsx|Todos os arquivos (*.*)|*.*";
                    saveDialog.Title = "Exportar Dados";
                    saveDialog.DefaultExt = "xml";
                    saveDialog.FileName = "Casamentos_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveDialog.FileName;
                        string extension = Path.GetExtension(filePath).ToLower();

                        if (extension == ".xml")
                        {
                            // Exportar para XML
                            ExportarParaXML(filePath);
                        }
                        else if (extension == ".csv")
                        {
                            // Exportar para CSV
                            ExportarParaCSV(filePath);
                        }
                        else if (extension == ".xlsx")
                        {
                            // Exportar para Excel (implementação básica)
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
                    for (int i = 0; i < dgvCasamentos.Columns.Count; i++)
                    {
                        headers += dgvCasamentos.Columns[i].HeaderText;
                        if (i < dgvCasamentos.Columns.Count - 1)
                            headers += ";";
                    }
                    sw.WriteLine(headers);

                    foreach (DataGridViewRow row in dgvCasamentos.Rows)
                    {
                        string line = string.Empty;
                        for (int i = 0; i < dgvCasamentos.Columns.Count; i++)
                        {
                            object cellValue = row.Cells[i].Value;
                            line += cellValue != null ? cellValue.ToString() : "";

                            if (i < dgvCasamentos.Columns.Count - 1)
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
                var casamentosView = (List<CasamentoView>)dgvCasamentos.DataSource;
                var casamentos = casamentosView.Select(cv => cv.ModeloOriginal).ToList();

                XmlSerializer serializer = new XmlSerializer(typeof(List<CasamentoModel>));

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

                    serializer.Serialize(writer, casamentos, ns);
                }

                MessageBox.Show($"Dados exportados com sucesso para {filePath}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao exportar para XML: {ex.Message}", ex);
            }
        }

        private void ListaCasamento_Load(object sender, EventArgs e)
        {
            CarregarCasamentos();
            dgvCasamentos.CellDoubleClick += DgvCasamentos_CellDoubleClick;
        }

        private void DgvCasamentos_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int id = Convert.ToInt32(dgvCasamentos.Rows[e.RowIndex].Cells["Id"].Value);

            var formCasamento = new AtosCartorio.Views.CasamentoForm(id);

            formCasamento.StartPosition = FormStartPosition.CenterScreen;

            this.Hide();

            if (formCasamento.ShowDialog() == DialogResult.OK)
            {
                CarregarCasamentos();
                this.Show();
            }
            else
            {
                this.Close();
            }
        }

        private void ListaCasamento_Shown(object sender, EventArgs e)
        {
            CarregarCasamentos();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                CarregarCasamentos();
                MessageBox.Show("Dados atualizados com sucesso!", "Atualização", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar os dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void CarregarCasamentos()
        {
            try
            {
                _context.ChangeTracker.Clear();
                
                List<CasamentoModel> casamentos = _casamentoRepository.GetAll(forceReload: true);

                var casamentosView = casamentos.Select(c => new CasamentoView
                {
                    Id = c.Id,
                    NomeConjuge1 = c.Conjuge1?.Nome ?? "Não informado",
                    NomeConjuge2 = c.Conjuge2?.Nome ?? "Não informado",
                    DataCasamento = c.DataCasamento,
                    DataRegistro = c.DataRegistro,
                    ModeloOriginal = c
                }).ToList();

                dgvCasamentos.DataSource = null;
                dgvCasamentos.DataSource = casamentosView;

                ConfigurarColunas();

                if (casamentos.Count == 0)
                {
                    MessageBox.Show("Não foram encontrados registros de casamento.",
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
            dgvCasamentos.AutoGenerateColumns = false;
            dgvCasamentos.Columns.Clear();

            dgvCasamentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "Id",
                Width = 100
            });

            dgvCasamentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NomeConjuge1",
                HeaderText = "Primeiro Cônjuge",
                Width = 350
            });

            dgvCasamentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NomeConjuge2",
                HeaderText = "Segundo Cônjuge",
                Width = 350
            });

            dgvCasamentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataCasamento",
                HeaderText = "Casamento",
                Width = 250,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });

            dgvCasamentos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataRegistro",
                HeaderText = "Registro",
                Width = 250,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });

            dgvCasamentos.AllowUserToAddRows = false;
            dgvCasamentos.AllowUserToDeleteRows = false;
            dgvCasamentos.ReadOnly = true;
            dgvCasamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCasamentos.MultiSelect = false;
            dgvCasamentos.RowHeadersVisible = false;
            dgvCasamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvCasamentos.AllowUserToResizeRows = false;

            dgvCasamentos.RowTemplate.Height = 37;
        }
    }
}
