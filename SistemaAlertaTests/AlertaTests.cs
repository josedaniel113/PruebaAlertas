using SistemaAlertas.Models;

namespace SistemaAlertaTests
{
    [TestClass]
    public class AlertaTests
    {
        [TestMethod]
        public void FechaEnvioYEsLeida_T()
        {
            // Arrange
            var mensaje = "Mensaje de prueba";

            // Act
            var alerta = new TestAlerta(mensaje);

            // Assert
            Assert.AreEqual(mensaje, alerta.Mensaje);
            Assert.IsFalse(alerta.EsLeida);
            Assert.IsTrue(alerta.FechaEnvio <= DateTime.Now);
        }

        [TestMethod]
        public void MarcarLeida_T()
        {
            // Arrange
            var alerta = new TestAlerta("Mensaje");

            // Act
            alerta.MarcarLeida();

            // Assert
            Assert.IsTrue(alerta.EsLeida);
        }

        [TestMethod]
        public void EstaExpirada_T()
        {
            // Arrange
            var alerta = new TestAlerta("Mensaje", DateTime.Now.AddMinutes(-1));

            // Act
            var resultado = alerta.EstaExpirada();

            // Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void NoEstaExpirada_T()
        {
            // Arrange
            var alerta = new TestAlerta("Mensaje", DateTime.Now.AddMinutes(1));

            // Act
            var resultado = alerta.EstaExpirada();

            // Assert
            Assert.IsFalse(resultado);
        }

        
        private class TestAlerta : Alerta
        {
            public TestAlerta(string mensaje, DateTime? fechaExpiracion = null)
                : base(mensaje, fechaExpiracion)
            {
            }
        }
    }
}
