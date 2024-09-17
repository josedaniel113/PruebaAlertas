namespace SistemaAlertas.Models
{
    public class Informativa : Alerta
    {
        public Informativa(string mensaje, DateTime? fechaExpiracion = null)
            : base(mensaje, fechaExpiracion)
        {
        }
    }
}
