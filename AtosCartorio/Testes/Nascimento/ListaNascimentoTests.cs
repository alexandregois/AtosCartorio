using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AtosCartorio.Data;
using AtosCartorio.Models;
using AtosCartorio.Repositories;
using AtosCartorio.Views.Nascimento;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AtosCartorio.Testes.Nascimento
{
    [TestClass]
    public class ListaNascimentoTests
    {
        [TestMethod]
        public void CarregarNascimentos_DadosExistentes_PreencheDataGridView()
        {
            // Arrange
            var mockNascimentos = new List<NascimentoModel>
            {
                new NascimentoModel
                {
                    Id = 1,
                    NomeCompleto = "João da Silva Jr",
                    DataNascimento = new DateTime(2023, 5, 15),
                    NomePai = "João da Silva",
                    NomeMae = "Maria da Silva",
                    DataRegistro = DateTime.Now,
                    CpfPai = "12345678901",
                    CpfMae = "98765432109"
                },
                new NascimentoModel
                {
                    Id = 2,
                    NomeCompleto = "Ana Pereira",
                    DataNascimento = new DateTime(2023, 6, 20),
                    NomePai = "Carlos Pereira",
                    NomeMae = "Joana Pereira",
                    DataRegistro = DateTime.Now,
                    CpfPai = "11122233344",
                    CpfMae = "55566677788"
                }
            };

            var mockRepository = new Mock<NascimentoRepository>();
            mockRepository.Setup(r => r.GetAll(It.IsAny<bool>())).Returns(mockNascimentos);

            var form = new ListaNascimento();
            
            // Injetar mock
            typeof(ListaNascimento).GetField("_nascimentoRepository", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(form, mockRepository.Object);

            // Act
            var method = typeof(ListaNascimento).GetMethod("CarregarNascimentos", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            method.Invoke(form, null);

            // Obter DataGridView
            var dgvNascimentos = (DataGridView)typeof(ListaNascimento).GetField("dgvNascimentos", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .GetValue(form);

            // Assert
            Assert.AreEqual(2, dgvNascimentos.Rows.Count);
            // Verificar se os IDs correspondem aos registros originais
            Assert.AreEqual(1, dgvNascimentos.Rows[0].Cells["Id"].Value);
            Assert.AreEqual(2, dgvNascimentos.Rows[1].Cells["Id"].Value);
        }

        [TestMethod]
        public void ExportarParaCSV_FormatoValido_CriaArquivoCorretamente()
        {
            // Arrange
            var mockNascimentos = new List<NascimentoModel>
            {
                new NascimentoModel
                {
                    Id = 1,
                    NomeCompleto = "João da Silva Jr",
                    DataNascimento = new DateTime(2023, 5, 15),
                    NomePai = "João da Silva",
                    NomeMae = "Maria da Silva",
                    DataRegistro = DateTime.Now,
                    CpfPai = "12345678901",
                    CpfMae = "98765432109"
                }
            };

            var mockRepository = new Mock<NascimentoRepository>();
            mockRepository.Setup(r => r.GetAll(It.IsAny<bool>())).Returns(mockNascimentos);

            var form = new ListaNascimento();
            
            // Injetar repository mock
            typeof(ListaNascimento).GetField("_nascimentoRepository", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(form, mockRepository.Object);

            // Carregar dados para o DataGridView
            var carregarMethod = typeof(ListaNascimento).GetMethod("CarregarNascimentos", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            carregarMethod.Invoke(form, null);

            // Criar um arquivo temporário para teste
            string testFilePath = System.IO.Path.GetTempFileName() + ".csv";

            try
            {
                // Act
                var exportMethod = typeof(ListaNascimento).GetMethod("ExportarParaCSV", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                exportMethod.Invoke(form, new object[] { testFilePath });

                // Assert
                Assert.IsTrue(System.IO.File.Exists(testFilePath));
                
                // Verificar conteúdo do arquivo
                string fileContent = System.IO.File.ReadAllText(testFilePath);
                Assert.IsTrue(fileContent.Contains("João da Silva Jr"));
                Assert.IsTrue(fileContent.Contains("João da Silva"));
                Assert.IsTrue(fileContent.Contains("Maria da Silva"));
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
    }
}
