using SistemaAlertas.Factories;
using SistemaAlertas.Services;

namespace SistemaAlertas
{
    class Program
    {
        static void Main(string[] args)
        {
            var alertaService = new AlertaService();

            var alerta1 = AlertaFactory.CrearAlerta("Urgente", "Mensaje urgente", DateTime.Now.AddMinutes(5));
            var alerta2 = AlertaFactory.CrearAlerta("Informativa", "Mensaje informativo", DateTime.Now.AddMinutes(10));

            alertaService.EnviarAlerta(alerta1);
            alertaService.EnviarAlerta(alerta2);

            var alertasNoLeidas = alertaService.AlertasNoLeidas();
            foreach (var alerta in alertasNoLeidas)
            {
                Console.WriteLine(alerta.Mensaje);
            }
        }
    }
}
