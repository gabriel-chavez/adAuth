using System;
using System.DirectoryServices;

namespace OperacionesBasicas
{
    public class ServicioActiveDirectory
    {
        public void Autenticar(string usuario, string contrasena)
        {
            var tipoAutenticacion =
                AuthenticationTypes.None | AuthenticationTypes.FastBind;

            var identificador =
                string.Format("uid={0},dc=example,dc=com", usuario);
            /*//ldap.forumsys.com:389/uid=newton,dc=example,dc=com*/
            using (var entry =
                new DirectoryEntry("LDAP://ldap.forumsys.com:389/dc=example,dc=com",
                    identificador,
                    contrasena,
                    tipoAutenticacion))
            {
                object nativeObject = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                //Verificamos que los datos de logeo proporcionados son correctos
                SearchResult result = search.FindOne();
                if (result == null)
                {
                    Console.WriteLine("ERROR");
                }
                else
                {
                    Console.WriteLine("CORRECTO");

                }
                Console.Read();
            }
        }

        public void CambiarContrasena(string usuario, string contrasenaAntigua, string contrasenaNueva)
        {
            var dn =
                string.Format("LDAP://localhost:389/CN={0},OU=ADAM users,DC=prueba,DC=adam", usuario);

            var tipoAutenticacion =
                AuthenticationTypes.Signing | AuthenticationTypes.Sealing
                | AuthenticationTypes.Secure;

            using (var entry = new DirectoryEntry(dn, null, null, tipoAutenticacion))
            {

                entry.RefreshCache();

                entry.Options.PasswordPort = 389;
                entry.Options.PasswordEncoding = PasswordEncodingMethod.PasswordEncodingClear;
                ;

                entry.Invoke("ChangePassword", new object[] {contrasenaAntigua, contrasenaNueva});

                entry.CommitChanges();
            }
        }

        public void ResetearContrasena(string usuario, string contrasenaNueva)
        {
            var dn =
                string.Format("LDAP://localhost:389/CN={0},OU=ADAM users,DC=prueba,DC=adam", usuario);

            var tipoAutenticacion =
                AuthenticationTypes.Signing | AuthenticationTypes.Sealing
                | AuthenticationTypes.Secure;

            using (var entry = new DirectoryEntry(dn, null, null, tipoAutenticacion))
            {

                entry.RefreshCache();

                entry.Options.PasswordPort = 389;
                entry.Options.PasswordEncoding = PasswordEncodingMethod.PasswordEncodingClear;
                ;

                entry.Invoke("SetPassword", new object[] { contrasenaNueva });

                entry.CommitChanges();
            }
        }

        public void ObtenerInformacionUsuario(string nombreUsuario)
        {
            var tipoAutenticacion =
               AuthenticationTypes.None | AuthenticationTypes.FastBind;

            var identificador =
                string.Format("uid={0},dc=example,dc=com", nombreUsuario);

            var contrasena = "password";
            using (var entryRoot = new DirectoryEntry("LDAP://ldap.forumsys.com:389/dc=example,dc=com",
                    identificador,
                    contrasena,
                    tipoAutenticacion))
            {
                using (var buscadorDirectorio = new DirectorySearcher(entryRoot))
                {

                    buscadorDirectorio.Filter =
                        string.Format("((sn={0}))", nombreUsuario);

                    //buscadorDirectorio.PropertiesToLoad.Add("businessCategory");
                    //buscadorDirectorio.PropertiesToLoad.Add("url");
                    //buscadorDirectorio.PropertiesToLoad.Add("mail");
                    //buscadorDirectorio.PropertiesToLoad.Add("company");
                    //buscadorDirectorio.PropertiesToLoad.Add("name");
                    DirectorySearcher search = new DirectorySearcher(entryRoot);
                    //Verificamos que los datos de logeo proporcionados son correctos
                    SearchResult result = search.FindOne();
                    if (result == null)
                    {
                        Console.WriteLine("ERROR");
                    }
                    else
                    {
                        Console.WriteLine("CORRECTO");

                    }
                    
                    buscadorDirectorio.PropertiesToLoad.Add("mail");
                    SearchResult resultado = buscadorDirectorio.FindOne();
                    //Console.WriteLine("DistinguishedName: {0}", resultado.Properties["distinguishedName"][0]);
                    //Console.WriteLine("BusinessCategory: {0}", resultado.Properties["businessCategory"][0]);
                    //Console.WriteLine("Url: {0}", resultado.Properties["url"][0]);
                    Console.WriteLine("Mail: {0}", resultado.Properties["mail"][0]);
                    //Console.WriteLine("Company: {0}", resultado.Properties["company"][0]);
                    //Console.WriteLine("Name: {0}", resultado.Properties["name"][0]);
                    Console.Read();
                }
            }
        }
    }
}
