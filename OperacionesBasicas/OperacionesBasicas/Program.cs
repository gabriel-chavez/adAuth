using System;

namespace OperacionesBasicas
{
    class Program
    {
        static void Main(string[] args)
        {
                var servicioAd = new ServicioActiveDirectory();

               servicioAd.ObtenerInformacionUsuario("gauss");
               // servicioAd.Autenticar("newton","password");

               // servicioAd.CambiarContrasena("testig", "tetsig1", "nuevoTest");

              //  servicioAd.ResetearContrasena("testig", "nuevoTest");
        }
    }
}
