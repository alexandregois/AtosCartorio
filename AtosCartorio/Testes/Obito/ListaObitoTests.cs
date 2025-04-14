using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AtosCartorio.Data;
using AtosCartorio.Models;
using AtosCartorio.Repositories;
using AtosCartorio.Views.Obito;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AtosCartorio.Testes.Obito
{
    [TestClass]
    public class ListaObitoTests
    {
        [TestMethod]
        public void CarregarObitos_DadosExistentes_PreencheDataGridView()
        {
            // Arrange
            var mockObitos = new List<ObitoModel>
            {
                new ObitoModel
                {
                    Id = 1,
                    NomeFalecido = "João da Silva",
                    DataFalecimento = new DateTime(2023, 5, 15),
                    DataNascimento = new DateTime(1950, 1, 1),
                    NomePai = "José da Silva",
                    NomeMae = "Maria da Silva",
                    DataRegistro = DateTime.Now
                },
                new ObitoModel
                {
                    Id = 2,
                    NomeFalecido = "Ana Pereira",
                    DataFalecimento = new DateTime(2023, 6, 20),
                    DataNascimento = new DateTime(1945, 3, 10),
                    NomePai = "Carlos Pereira",
                    NomeMae = "Joana Pereira",
                    DataRegistro = DateTime.Now
                }
            };

            var mockRepository = new Mock<ObitoRepository>();
            mockRepository.Setup(r => r.GetAll(It.IsAny<bool>())).Returns(mockObitos);

            var form = new ListaObito();
            
            // Injetar mock
            typeof(ListaObito).GetField("_obitoRepository", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(form, mockRepository.Object);

            // Act
            var method = typeof(ListaObito).GetMethod("CarregarObitos", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            method.Invoke(form, null);

            // Obter DataGridView
            var dgvObitos = (DataGridView)typeof(ListaObito).GetField("dgvObitos", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .GetValue(form);

            // Assert
            Assert.AreEqual(2, dgvObitos.Rows.Count);
            // Verificar se os IDs correspondem aos registros originais
            Assert.AreEqual(1, dgvObitos.Rows[0].Cells["Id"].Value);
            Assert.AreEqual(2, dgvObitos.Rows[1].Cells["Id"].Value);
        }

        [TestMethod]
        public void ExportarParaCSV_FormatoValido_CriaArquivoCorretamente()
        {
            // Arrange
            var mockObitos = new List<ObitoModel>
            {
                new ObitoModel
                {
                    Id = 1,
                    NomeFalecido = "João da Silva",
                    DataFalecimento = new DateTime(2023, 5, 15),
                    DataNascimento = new DateTime(1950, 1, 1),
                    NomePai = "José da Silva",
                    NomeMae = "Maria da Silva",
                    DataRegistro = DateTime.Now
                }
            };

            var mockRepository = new Mock<ObitoRepository>();
            mockRepository.Setup(r => r.GetAll(It.IsAny<bool>())).Returns(mockObitos);

            var form = new ListaObito();
            
            // Injetar repository mock
            typeof(ListaObito).GetField("_obitoRepository", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(form, mockRepository.Object);

            // Carregar dados para o DataGridView
            var carregarMethod = typeof(ListaObito).GetMethod("CarregarObitos", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            carregarMethod.Invoke(form, null);

            // Criar um arquivo temporário para teste
            string testFilePath = System.IO.Path.GetTempFileName() + ".csv";

            try
            {
                // Act
                var exportMethod = typeof(ListaObito).GetMethod("ExportarParaCSV", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                exportMethod.Invoke(form, new object[] { testFilePath });

                // Assert
                Assert.IsTrue(System.IO.File.Exists(testFilePath));
                
                // Verificar conteúdo do arquivo
                string fileContent = System.IO.File.ReadAllText(testFilePath);
                Assert.IsTrue(fileContent.Contains("João da Silva"));
                Assert.IsTrue(fileContent.Contains("José da Silva"));
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
