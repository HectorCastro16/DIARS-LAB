﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace CapaPersistencia
{
    public class Conexion
    {

        #region singleton
        private static readonly Conexion _instancia = new Conexion();
        public static Conexion Instancia
        {
            get { return Conexion._instancia; }
        }
        #endregion


        #region metodos

        public SqlConnection Conectar() {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data source=.; Initial Catalog=VentaPasajes ; Integrated Security=true";
            return cn;
        }

        #endregion

    }
}
