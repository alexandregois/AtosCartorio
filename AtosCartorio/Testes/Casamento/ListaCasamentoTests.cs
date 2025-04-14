using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AtosCartorio.Data;
using AtosCartorio.Models;
using AtosCartorio.Repositories;
using AtosCartorio.Views.Casamento;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AtosCartorio.Testes.Casamento
{
    [TestClass]
    public class ListaCasamentoTests
    {
        [TestMethod]
        public void CarregarCasamentos_DadosExistentes_PreencheDataGridView()
        {
            // Arrange
            var mockCasamentos = new List<CasamentoModel>
            {
                new CasamentoModel
                {
                    Id = 1,
                    Conjuge1 = new ConjugeModel { Nome = "João da Silva" },
                    Conjuge2 = new ConjugeModel { Nome = "Maria Souza" },
                    DataCasamento = new DateTime(2023, 5, 15),
                    DataRegistro = DateTime.Now
                },
                new CasamentoModel
                {
                    Id = 2,
                    Conjuge1 = new ConjugeModel { Nome = "Carlos Pereira" },
                    Conjuge2 = new ConjugeModel { Nome = "Ana Santos" },
                    DataCasamento = new DateTime(2023, 6, 20),
                    DataRegistro = DateTime.Now
                }
            };

            var mockRepository = new Mock<CasamentoRepository>();
            mockRepository.Setup(r => r.GetAll(It.IsAny<bool>())).Returns(mockCasamentos);

            var form = new ListaCasamento();
            
            // Injetar mock
            typeof(ListaCasamento).GetField("_casamentoRepository", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(form, mockRepository.Object);

            // Act
            var method = typeof(ListaCasamento).GetMethod("CarregarCasamentos", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            method.Invoke(form, null);

            // Obter DataGridView
            var dgvCasamentos = (DataGridView)typeof(ListaCasamento).GetField("dgvCasamentos", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .GetValue(form);

            // Assert
            Assert.AreEqual(2, dgvCasamentos.Rows.Count);
            // Verificar se os IDs correspondem aos registros originais
            Assert.AreEqual(1, dgvCasamentos.Rows[0].Cells["Id"].Value);
            Assert.AreEqual(2, dgvCasamentos.Rows[1].Cells["Id"].Value);
        }

        [TestMethod]
        public void ExportarParaCSV_FormatoValido_CriaArquivoCorretamente()
        {
            // Arrange
            var mockCasamentos = new List<CasamentoModel>
            {
                new CasamentoModel
                {
                    Id = 1,
                    Conjuge1 = new ConjugeModel { Nome = "João da Silva" },
                    Conjuge2 = new ConjugeModel { Nome = "Maria Souza" },
                    DataCasamento = new DateTime(2023, 5, 15),
                    DataRegistro = DateTime.Now
                }
            };

            var mockRepository = new Mock<CasamentoRepository>();
            mockRepository.Setup(r => r.GetAll(It.IsAny<bool>())).Returns(mockCasamentos);

            var form = new ListaCasamento();
            
            // Injetar repository mock
            typeof(ListaCasamento).GetField("_casamentoRepository", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(form, mockRepository.Object);

            // Carregar dados para o DataGridView
            var carregarMethod = typeof(ListaCasamento).GetMethod("CarregarCasamentos", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            carregarMethod.Invoke(form, null);

            // Criar um arquivo temporário para teste
            string testFilePath = System.IO.Path.GetTempFileName() + ".csv";

            try
            {
                // Act
                var exportMethod = typeof(ListaCasamento).GetMethod("ExportarParaCSV", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                exportMethod.Invoke(form, new object[] { testFilePath });

                // Assert
                Assert.IsTrue(System.IO.File.Exists(testFilePath));
                
                // Verificar conteúdo do arquivo
                string fileContent = System.IO.File.ReadAllText(testFilePath);
                Assert.IsTrue(fileContent.Contains("João da Silva"));
                Assert.IsTrue(fileContent.Contains("Maria Souza"));
            }
            finally
            {
                // Limpar
                if (System.IO.File.Exists(testFilePath))
                {
                    System.IO.File.Delete(testFilePath);
                }
            }
        }

        [TestMethod]
        public void btnAtualizar_Click_AtualizaDataGridView()
        {
            // Arrange
            var mockCasamentos = new List<CasamentoModel>
            {
                new CasamentoModel
                {
                    Id = 1,
                    Conjuge1 = new ConjugeModel { Nome = "João da Silva" },
                    Conjuge2 = new ConjugeModel { Nome = "Maria Souza" },
                    DataCasamento = new DateTime(2023, 5, 15),
                    DataRegistro = DateTime.Now
                }
            };

            var mockRepository = new Mock<CasamentoRepository>();
            mockRepository.Setup(r => r.GetAll(It.IsAny<bool>())).Returns(mockCasamentos);

            var form = new ListaCasamento();
            
            // Injetar mock
            typeof(ListaCasamento).GetField("_casamentoRepository", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(form, mockRepository.Object);

            // Simular o clique no botão Atualizar
            var btnAtualizar = (Button)typeof(ListaCasamento).GetField("btnAtualizar", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            
            // Act
            // Simular o clique no botão Atualizar através do método associado ao evento
            var clickMethod = typeof(ListaCasamento).GetMethod("btnAtualizar_Click", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            clickMethod.Invoke(form, new object[] { btnAtualizar, EventArgs.Empty });

            // Obter DataGridView
            var dgvCasamentos = (DataGridView)typeof(ListaCasamento).GetField("dgvCasamentos", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .GetValue(form);

            // Assert
            // Verificar se o método GetAll foi chamado com o parâmetro forceReload=true
            mockRepository.Verify(r => r.GetAll(true), Times.Once);
            // Verificar se a grade foi preenchida com os dados
            Assert.AreEqual(1, dgvCasamentos.Rows.Count);
        }
    }
}
