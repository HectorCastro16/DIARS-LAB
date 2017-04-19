using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaDominio;

namespace CapaPersistencia
{
    public class daoUsuario
    {
        #region singleton
        private static readonly daoUsuario _instancia = new daoUsuario();
        public static daoUsuario Instancia
        {
            get { return daoUsuario._instancia; }
        }
        #endregion

        #region metodos

        public entUsuario VerificarAcceso(String Usuario, String Password)
        {
            SqlCommand cmd = null;
            entUsuario u = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spVerificarAcceso",cn);

                cmd.Parameters.AddWithValue("@prmstrUsuario", Usuario);
                cmd.Parameters.AddWithValue("@prmstrPassword", Password);

                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    u = new entUsuario();
                    u.idUsuario = Convert.ToInt16(dr["idUsuario"]);
                    u.NombreUsuario = dr["NombreUsuario"].ToString();
                    u.Activo = Convert.ToBoolean(dr["Activo"]);
                    entPersona p = new entPersona();
                    p.idPersona = Convert.ToInt16(dr["idPersona"]);
                    p.PrimerNombre = dr["PrimerNombre"].ToString();
                    p.SegundoNombre = dr["SegundoNombre"].ToString();
                    p.ApellidoPaterno = dr["ApellidoPaterno"].ToString();
                    p.ApellidoMaterno = dr["ApellidoMaterno"].ToString();
                    p.DNI = dr["DNI"].ToString();
                    u.Persona = p;
                }
                return u;
            }
            catch (Exception e){throw e;
            }finally { cmd.Connection.Close(); }
        }

        #endregion

    }
}
