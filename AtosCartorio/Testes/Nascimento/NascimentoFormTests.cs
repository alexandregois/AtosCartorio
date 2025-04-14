using System;
using System.Windows.Forms;
using AtosCartorio.Data;
using AtosCartorio.Models;
using AtosCartorio.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AtosCartorio.Testes.Nascimento
{
    [TestClass]
    public class NascimentoFormTests
    {
        [TestMethod]
        public void ValidarCamposTexto_DadosValidos_RetornaVerdadeiro()
        {
            // Arrange
            var form = new NascimentoForm();
            typeof(NascimentoForm).GetField("_context", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(form, CreateMockContext());

            // Simular preenchimento dos campos
            var txtNomeRegistrado = (TextBox)typeof(NascimentoForm).GetField("txtNomeRegistrado", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomePai = (TextBox)typeof(NascimentoForm).GetField("txtNomePai", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomeMae = (TextBox)typeof(NascimentoForm).GetField("txtNomeMae", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);

            txtNomeRegistrado.Text = "Nome do Registrado Teste";
            txtNomePai.Text = "Nome do Pai do Registrado Teste";
            txtNomeMae.Text = "Nome da Mãe do Registrado Teste";

            // Act
            var method = typeof(NascimentoForm).GetMethod("ValidarCamposTexto", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var result = (bool)method.Invoke(form, null);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidarCamposTexto_NomeRegistradoInvalido_RetornaFalso()
        {
            // Arrange
            var form = new NascimentoForm();
            typeof(NascimentoForm).GetField("_context", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(form, CreateMockContext());

            // Simular preenchimento dos campos
            var txtNomeRegistrado = (TextBox)typeof(NascimentoForm).GetField("txtNomeRegistrado", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomePai = (TextBox)typeof(NascimentoForm).GetField("txtNomePai", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomeMae = (TextBox)typeof(NascimentoForm).GetField("txtNomeMae", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);

            txtNomeRegistrado.Text = "Nome";  // Nome curto, inválido
            txtNomePai.Text = "Nome do Pai do Registrado Teste";
            txtNomeMae.Text = "Nome da Mãe do Registrado Teste";

            // Act
            var method = typeof(NascimentoForm).GetMethod("ValidarCamposTexto", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var result = (bool)method.Invoke(form, null);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CarregarRegistro_RegistroExistente_PreencheCamposCorretamente()
        {
            // Arrange
            int registroId = 1;
            var mockNascimento = new NascimentoModel
            {
                Id = registroId,
                NomeCompleto = "Nome do Registrado Teste",
                NomePai = "Nome do Pai Teste",
                NomeMae = "Nome da Mãe Teste",
                DataNascimento = new DateTime(2023, 5, 15),
                DataRegistro = DateTime.Now,
                DataNascimentoPai = new DateTime(1980, 5, 10),
                DataNascimentoMae = new DateTime(1985, 8, 20),
                CpfPai = "12345678901",
                CpfMae = "98765432109"
            };

            var mockContext = CreateMockContextWithData(mockNascimento);
            
            // Act - Criar formulário com o ID
            var form = new NascimentoForm(registroId);
            typeof(NascimentoForm).GetField("_context", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(form, mockContext);

            var method = typeof(NascimentoForm).GetMethod("CarregarRegistro", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            method.Invoke(form, new object[] { registroId });

            // Obter valores dos campos
            var txtNomeRegistrado = (TextBox)typeof(NascimentoForm).GetField("txtNomeRegistrado", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomePai = (TextBox)typeof(NascimentoForm).GetField("txtNomePai", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomeMae = (TextBox)typeof(NascimentoForm).GetField("txtNomeMae", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtCpfPai = (TextBox)typeof(NascimentoForm).GetField("txtCpfPai", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtCpfMae = (TextBox)typeof(NascimentoForm).GetField("txtCpfMae", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            
            // Assert
            Assert.AreEqual(mockNascimento.NomeCompleto, txtNomeRegistrado.Text);
            Assert.AreEqual(mockNascimento.NomePai, txtNomePai.Text);
            Assert.AreEqual(mockNascimento.NomeMae, txtNomeMae.Text);
            Assert.AreEqual(mockNascimento.CpfPai, txtCpfPai.Text);
            Assert.AreEqual(mockNascimento.CpfMae, txtCpfMae.Text);
        }

        private CartorioContext CreateMockContext()
        {
            var mockContext = new Mock<CartorioContext>();
            return mockContext.Object;
        }

        private CartorioContext CreateMockContextWithData(NascimentoModel nascimento)
        {
            var mockContext = new Mock<CartorioContext>();
            mockContext.Setup(c => c.Nascimentos.Find(nascimento.Id)).Returns(nascimento);
            return mockContext.Object;
        }
    }
}
