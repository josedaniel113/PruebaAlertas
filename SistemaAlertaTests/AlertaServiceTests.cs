using SistemaAlertas.Models;
using SistemaAlertas.Services;

namespace SistemaAlertaTests
{
    [TestClass]
    public class AlertaServiceTests
    {
        [TestMethod]
        public void EnviarAlerta_T()
        {
            // Arrange
            var alertaService = new AlertaService();
            var alerta = new Informativa("Mensaje");

            // Act
            alertaService.EnviarAlerta(alerta);

            // Assert
            var alertasNoLeidas = alertaService.AlertasNoLeidas();
            Assert.AreEqual(1, alertasNoLeidas.Count);
            Assert.AreEqual(alerta.Mensaje, alertasNoLeidas[0].Mensaje);
        }

        [TestMethod]
        public void AlertasNoLeidas_T()
        {
            // Arrange
            var alertaService = new AlertaService();
            var alertaUrgente1 = new Urgente("Urgente 1", DateTime.Now.AddMinutes(5));
            var alertaInformativa1 = new Informativa("Informativa 1", DateTime.Now.AddMinutes(10));
            var alertaUrgente2 = new Urgente("Urgente 2", DateTime.Now.AddMinutes(15));

            alertaService.EnviarAlerta(alertaUrgente1);
            alertaService.EnviarAlerta(alertaInformativa1);
            alertaService.EnviarAlerta(alertaUrgente2);

            // Act
            var alertasNoLeidas = alertaService.AlertasNoLeidas();

            // Assert
            Assert.AreEqual(3, alertasNoLeidas.Count);
            Assert.AreEqual("Urgente 2", alertasNoLeidas[0].Mensaje);
            Assert.AreEqual("Urgente 1", alertasNoLeidas[1].Mensaje);
            Assert.AreEqual("Informativa 1", alertasNoLeidas[2].Mensaje);
        }
    }
}
