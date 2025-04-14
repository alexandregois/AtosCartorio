using System;
using System.Windows.Forms;
using AtosCartorio.Data;
using AtosCartorio.Models;
using AtosCartorio.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AtosCartorio.Testes.Obito
{
    [TestClass]
    public class ObitoFormTests
    {
        [TestMethod]
        public void ValidarCamposTexto_DadosValidos_RetornaVerdadeiro()
        {
            // Arrange
            var form = new ObitoForm();
            typeof(ObitoForm).GetField("_context", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(form, CreateMockContext());

            // Simular preenchimento dos campos
            var txtNomeFalecido = (TextBox)typeof(ObitoForm).GetField("txtNomeFalecido", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomePai = (TextBox)typeof(ObitoForm).GetField("txtNomePai", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomeMae = (TextBox)typeof(ObitoForm).GetField("txtNomeMae", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);

            txtNomeFalecido.Text = "Nome do Falecido Teste";
            txtNomePai.Text = "Nome do Pai do Falecido Teste";
            txtNomeMae.Text = "Nome da Mãe do Falecido Teste";

            // Act
            var method = typeof(ObitoForm).GetMethod("ValidarCamposTexto", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var result = (bool)method.Invoke(form, null);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidarCamposTexto_NomeFalecidoInvalido_RetornaFalso()
        {
            // Arrange
            var form = new ObitoForm();
            typeof(ObitoForm).GetField("_context", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(form, CreateMockContext());

            // Simular preenchimento dos campos
            var txtNomeFalecido = (TextBox)typeof(ObitoForm).GetField("txtNomeFalecido", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomePai = (TextBox)typeof(ObitoForm).GetField("txtNomePai", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomeMae = (TextBox)typeof(ObitoForm).GetField("txtNomeMae", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);

            txtNomeFalecido.Text = "Nome";  // Nome curto, inválido
            txtNomePai.Text = "Nome do Pai do Falecido Teste";
            txtNomeMae.Text = "Nome da Mãe do Falecido Teste";

            // Act
            var method = typeof(ObitoForm).GetMethod("ValidarCamposTexto", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var result = (bool)method.Invoke(form, null);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CarregarRegistro_RegistroExistente_PreencheCamposCorretamente()
        {
            // Arrange
            int registroId = 1;
            var mockObito = new ObitoModel
            {
                Id = registroId,
                NomeFalecido = "Nome do Falecido Teste",
                NomePai = "Nome do Pai Teste",
                NomeMae = "Nome da Mãe Teste",
                DataFalecimento = new DateTime(2023, 5, 15),
                DataNascimento = new DateTime(1950, 1, 1),
                DataRegistro = DateTime.Now,
                DataNascimentoPai = new DateTime(1920, 5, 10),
                DataNascimentoMae = new DateTime(1925, 8, 20)
            };

            var mockContext = CreateMockContextWithData(mockObito);
            
            // Act - Criar formulário com o ID
            var form = new ObitoForm(registroId);
            typeof(ObitoForm).GetField("_context", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(form, mockContext);

            var method = typeof(ObitoForm).GetMethod("CarregarRegistro", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            method.Invoke(form, new object[] { registroId });

            // Obter valores dos campos
            var txtNomeFalecido = (TextBox)typeof(ObitoForm).GetField("txtNomeFalecido", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomePai = (TextBox)typeof(ObitoForm).GetField("txtNomePai", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            var txtNomeMae = (TextBox)typeof(ObitoForm).GetField("txtNomeMae", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(form);
            
            // Assert
            Assert.AreEqual(mockObito.NomeFalecido, txtNomeFalecido.Text);
            Assert.AreEqual(mockObito.NomePai, txtNomePai.Text);
            Assert.AreEqual(mockObito.NomeMae, txtNomeMae.Text);
        }

        private CartorioContext CreateMockContext()
        {
            var mockContext = new Mock<CartorioContext>();
            return mockContext.Object;
        }

        private CartorioContext CreateMockContextWithData(ObitoModel obito)
        {
            var mockContext = new Mock<CartorioContext>();
            mockContext.Setup(c => c.Obitos.Find(obito.Id)).Returns(obito);
            return mockContext.Object;
        }
    }
}
