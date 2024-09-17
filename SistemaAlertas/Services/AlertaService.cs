using SistemaAlertas.Models;

namespace SistemaAlertas.Services
{
    public class AlertaService
    {
        private List<Alerta> alertas = new List<Alerta>();

        public void EnviarAlerta(Alerta alerta)
        {
            alertas.Add(alerta);
        }

        public List<Alerta> AlertasNoLeidas()
        {
            return alertas
            .Where(a => !a.EsLeida && !a.EstaExpirada())
            .OrderByDescending(a => a is Urgente)
            .ThenByDescending(a => a.FechaEnvio)
            .ToList();
        }

    }
}
