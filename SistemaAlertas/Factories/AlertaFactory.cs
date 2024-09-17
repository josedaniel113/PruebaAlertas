using SistemaAlertas.Models;

namespace SistemaAlertas.Factories
{
    public static class AlertaFactory
    {
        public static Alerta CrearAlerta(string tipoAlerta, string mensaje, DateTime? fechaExpiracion)
        {
            if (tipoAlerta == "Urgente")
            {
                return new Urgente(mensaje, fechaExpiracion);
            }
            else if (tipoAlerta == "Informativa")
            {
                return new Informativa(mensaje, fechaExpiracion);
            }
            throw new ArgumentException("Tipo de alerta no válido.");
        }
    }
}
