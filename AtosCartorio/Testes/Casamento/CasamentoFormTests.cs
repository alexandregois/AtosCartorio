using System;
using System.Windows.Forms;
using AtosCartorio.Data;
using AtosCartorio.Models;
using AtosCartorio.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AtosCartorio.Testes.Casamento
{
    [TestClass]
    public class CasamentoFormTests
    {
        [TestMethod]
        public void ValidarCamposTexto_DadosValidos_RetornaVerdadeiro()
        {
            // Arrange
            var form = new CasamentoForm();
            typeof(CasamentoForm).GetField("_context", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(form, CreateMockContext());

            // Simular preenchimento dos campos
            var txtNomeConjuge1 = (TextBox)typeof(CasamentoForm).GetField("txtNomeConjuge1", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomePaiConjuge1 = (TextBox)typeof(CasamentoForm).GetField("txtNomePaiConjuge1", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomeMaeConjuge1 = (TextBox)typeof(CasamentoForm).GetField("txtNomeMaeConjuge1", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomeConjuge2 = (TextBox)typeof(CasamentoForm).GetField("txtNomeConjuge2", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomePaiConjuge2 = (TextBox)typeof(CasamentoForm).GetField("txtNomePaiConjuge2", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomeMaeConjuge2 = (TextBox)typeof(CasamentoForm).GetField("txtNomeMaeConjuge2", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);

            txtNomeConjuge1.Text = "Nome do Primeiro Cônjuge";
            txtNomePaiConjuge1.Text = "Nome do Pai do Primeiro Cônjuge";
            txtNomeMaeConjuge1.Text = "Nome da Mãe do Primeiro Cônjuge";
            txtNomeConjuge2.Text = "Nome do Segundo Cônjuge";
            txtNomePaiConjuge2.Text = "Nome do Pai do Segundo Cônjuge";
            txtNomeMaeConjuge2.Text = "Nome da Mãe do Segundo Cônjuge";

            // Act
            var method = typeof(CasamentoForm).GetMethod("ValidarCamposTexto", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var result = (bool)method.Invoke(form, null);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidarCamposTexto_NomeConjuge1Invalido_RetornaFalso()
        {
            // Arrange
            var form = new CasamentoForm();
            typeof(CasamentoForm).GetField("_context", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(form, CreateMockContext());

            // Simular preenchimento dos campos
            var txtNomeConjuge1 = (TextBox)typeof(CasamentoForm).GetField("txtNomeConjuge1", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomePaiConjuge1 = (TextBox)typeof(CasamentoForm).GetField("txtNomePaiConjuge1", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomeMaeConjuge1 = (TextBox)typeof(CasamentoForm).GetField("txtNomeMaeConjuge1", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomeConjuge2 = (TextBox)typeof(CasamentoForm).GetField("txtNomeConjuge2", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomePaiConjuge2 = (TextBox)typeof(CasamentoForm).GetField("txtNomePaiConjuge2", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomeMaeConjuge2 = (TextBox)typeof(CasamentoForm).GetField("txtNomeMaeConjuge2", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);

            txtNomeConjuge1.Text = "Nome";  // Nome curto, inválido
            txtNomePaiConjuge1.Text = "Nome do Pai do Primeiro Cônjuge";
            txtNomeMaeConjuge1.Text = "Nome da Mãe do Primeiro Cônjuge";
            txtNomeConjuge2.Text = "Nome do Segundo Cônjuge";
            txtNomePaiConjuge2.Text = "Nome do Pai do Segundo Cônjuge";
            txtNomeMaeConjuge2.Text = "Nome da Mãe do Segundo Cônjuge";

            // Act
            var method = typeof(CasamentoForm).GetMethod("ValidarCamposTexto", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var result = (bool)method.Invoke(form, null);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CarregarRegistro_RegistroExistente_PreencheCamposCorretamente()
        {
            // Arrange
            int registroId = 1;
            var conjuge1 = new ConjugeModel
            {                
                Nome = "Primeiro Cônjuge",
                NomePai = "Pai do Primeiro Cônjuge",
                NomeMae = "Mãe do Primeiro Cônjuge",
                DataNascimento = new DateTime(1980, 5, 10)
            };

            var conjuge2 = new ConjugeModel
            {                
                Nome = "Segundo Cônjuge",
                NomePai = "Pai do Segundo Cônjuge",
                NomeMae = "Mãe do Segundo Cônjuge",
                DataNascimento = new DateTime(1982, 3, 15)
            };

            var mockCasamento = new CasamentoModel
            {
                Id = registroId,
                Conjuge1 = conjuge1,
                Conjuge2 = conjuge2,
                DataCasamento = new DateTime(2023, 7, 15),
                DataRegistro = DateTime.Now
            };

            var mockContext = CreateMockContextWithData(mockCasamento);
            
            // Act - Criar formulário com o ID
            var form = new CasamentoForm(registroId);
            typeof(CasamentoForm).GetField("_context", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(form, mockContext);

            var method = typeof(CasamentoForm).GetMethod("CarregarRegistro", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            method.Invoke(form, new object[] { registroId });

            // Obter valores dos campos
            var txtNomeConjuge1 = (TextBox)typeof(CasamentoForm).GetField("txtNomeConjuge1", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomePaiConjuge1 = (TextBox)typeof(CasamentoForm).GetField("txtNomePaiConjuge1", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomeMaeConjuge1 = (TextBox)typeof(CasamentoForm).GetField("txtNomeMaeConjuge1", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomeConjuge2 = (TextBox)typeof(CasamentoForm).GetField("txtNomeConjuge2", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomePaiConjuge2 = (TextBox)typeof(CasamentoForm).GetField("txtNomePaiConjuge2", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomeMaeConjuge2 = (TextBox)typeof(CasamentoForm).GetField("txtNomeMaeConjuge2", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            
            // Assert
            Assert.AreEqual(conjuge1.Nome, txtNomeConjuge1.Text);
            Assert.AreEqual(conjuge1.NomePai, txtNomePaiConjuge1.Text);
            Assert.AreEqual(conjuge1.NomeMae, txtNomeMaeConjuge1.Text);
            Assert.AreEqual(conjuge2.Nome, txtNomeConjuge2.Text);
            Assert.AreEqual(conjuge2.NomePai, txtNomePaiConjuge2.Text);
            Assert.AreEqual(conjuge2.NomeMae, txtNomeMaeConjuge2.Text);
        }

        private CartorioContext CreateMockContext()
        {
            var mockContext = new Mock<CartorioContext>();
            return mockContext.Object;
        }

        private CartorioContext CreateMockContextWithData(CasamentoModel casamento)
        {
            var mockContext = new Mock<CartorioContext>();
            mockContext.Setup(c => c.Casamentos.Find(casamento.Id)).Returns(casamento);
            return mockContext.Object;
        }
    }
}
