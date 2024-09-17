namespace SistemaAlertas.Models
{
    public class Urgente : Alerta
    {
        public Urgente(string mensaje, DateTime? fechaExpiracion = null)
        : base(mensaje, fechaExpiracion) 
        {
        }
    }
}
