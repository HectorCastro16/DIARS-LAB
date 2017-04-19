using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaPersistencia;


namespace CapaAplicacion
{
    public class appUsuario
    {
        #region singleton
        private static readonly appUsuario _instancia = new appUsuario();
        public static appUsuario Instancia
        {
            get { return appUsuario._instancia; }
        }
        #endregion

        public Boolean VerificarAcceso(String Usuario, String Password) {
            try
            {
                entUsuario u = daoUsuario.Instancia.VerificarAcceso(Usuario,Password);
                entUsuario ux = new entUsuario();
                return ux.VerificarAcceso(u);
            }
            catch (Exception e)
            {
                
                throw e;
            }


        }

    }
}
