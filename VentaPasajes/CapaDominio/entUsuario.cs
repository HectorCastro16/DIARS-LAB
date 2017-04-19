using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDominio
{
    public class entUsuario
    {
        public int idUsuario { get; set; }
        public entPersona Persona { get; set; }
        public String NombreUsuario { get; set; }
        public String Password { get; set; }
        public Boolean Activo { get; set; }

        public Boolean VerificarAcceso(entUsuario u)
        {
            try
            {
                Boolean estado=false;
                if(u!=null){
                    estado=true;
                }
                return estado;
            }
            catch (Exception e)
            {
                
                throw e;
            }

        }


    }

    
}
