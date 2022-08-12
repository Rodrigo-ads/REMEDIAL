using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;
using System.Data.SqlClient;

namespace BL
{
    public class Nego
    {
        Acceso objAct = new Acceso();

        public SqlDataReader ObtenerTablas(string tabla)
        {
            return objAct.Select(tabla);
        }

        public string InsertaConexion(Conexion con)
        {
            return objAct.InsertaConexion(con);
        }

        public SqlDataReader ConsultaConexion()
        {
            return objAct.ConsultaConexion();
        }
    }
}
