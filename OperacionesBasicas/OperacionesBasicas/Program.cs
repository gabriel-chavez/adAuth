using System;

namespace OperacionesBasicas
{
    class Program
    {
        static void Main(string[] args)
        {
            var servicioAd = new ServicioActiveDirectory();
            //servicioAd.ObtenerInformacionUsuario("gauss");
            // servicioAd.Autenticar("lchavez","Mañana123");
            //if(servicioAd.IsAuthenticated(@"LDAP://10.9.0.12:389/DC=bsol,DC=com,DC=bo", @"bsol\lchavez", "Mañana12w3"))
            //{
            //    Console.WriteLine("Correcto");
            //}
            //else
            //{
            //    Console.WriteLine("error");
            //}
            //Console.Read();
            // servicioAd.CambiarContrasena("testig", "tetsig1", "nuevoTest");
            //  servicioAd.ResetearContrasena("testig", "nuevoTest");
            /************************************************/
            var ldap = new LdapAutenticar(@"LDAP://10.9.0.12:389/DC=bsol,DC=com,DC=bo");
            ldap=ldap.IsAuthenticated(@"bsol\lchavez", "Mañana123");
            if(ldap.autendicado)
            {
                Console.WriteLine("correcto");
            }
            else
            {
                Console.WriteLine(ldap.mensaje);
            }
            Console.Read();
        }
    }
}
