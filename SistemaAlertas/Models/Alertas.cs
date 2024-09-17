namespace SistemaAlertas.Models
{
    public abstract class Alerta
    {
        public string Mensaje { get; protected set; }

        public DateTime FechaEnvio { get; private set; }
        public DateTime? FechaExpiracion { get; protected set; }
        public bool EsLeida { get; private set; }

        public Alerta(string mensaje, DateTime? fechaExpiracion = null)
        {
            Mensaje = mensaje;
            FechaEnvio = DateTime.Now;
            FechaExpiracion = fechaExpiracion;
            EsLeida = false;
        }

        public void MarcarLeida()
        {
            EsLeida = true;
        }

        public bool EstaExpirada()
        {
            return FechaExpiracion.HasValue && FechaExpiracion.Value < DateTime.Now;
        }

    }
}
