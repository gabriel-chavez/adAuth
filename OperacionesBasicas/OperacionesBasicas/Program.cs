using System;

namespace OperacionesBasicas
{
    class Program
    {
        static void Main(string[] args)
        {
                var servicioAd = new ServicioActiveDirectory();

                servicioAd.ObtenerInformacionUsuario("testig");
                servicioAd.Autenticar("testig","testig1");

                servicioAd.CambiarContrasena("testig", "tetsig1", "nuevoTest");

                servicioAd.ResetearContrasena("testig", "nuevoTest");
        }
    }
}
