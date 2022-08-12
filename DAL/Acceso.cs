using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Entidades;


namespace DAL
{
    public class Acceso
    {
        private string Cadena;
        public Acceso()
        {
            Cadena = ConfigurationManager.ConnectionStrings["Taller"].ConnectionString;
        }
        public SqlDataReader Select(string table)
        {
            SqlConnection conexion = new SqlConnection(Cadena);
            conexion.Open();
            SqlDataReader reader;
            SqlCommand com = new SqlCommand();
            com.Connection = conexion;
            com.CommandText = "select * from " + table;
            reader = com.ExecuteReader();
            return reader;
        }


        public string InsertaConexion(Conexion con_auto)
        {
            string respuesta = "";
            SqlConnection conexion = new SqlConnection(Cadena);
            conexion.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conexion;
            com.Parameters.AddWithValue("@Cliente", con_auto.Cliente);
            com.Parameters.AddWithValue("@Automovil", con_auto.Auto);
            com.Parameters.AddWithValue("@Marca", con_auto.Marca);
            com.Parameters.AddWithValue("@Mecanico", con_auto.Mecanico);
            com.Parameters.AddWithValue("@Fecha", con_auto.Fecha);
            com.Parameters.AddWithValue("@Descripcion", con_auto.Descripcion);
            com.CommandText = "INSERT INTO Conexion VALUES(@Cliente, @Automovil, @Marca, @Mecanico, @Fecha, @Descripcion);";
            com.ExecuteNonQuery();
            respuesta = "Se creó una nueva conexión";
            return respuesta;
        }

        public SqlDataReader ConsultaConexion()
        {
            SqlConnection conexion = new SqlConnection(Cadena);
            conexion.Open();
            SqlDataReader reader;
            SqlCommand com = new SqlCommand();
            com.Connection = conexion;
            com.CommandText = @"SELECT
            Cliente.Nombre,
            Cliente.App,
            Cliente.ApM,
            Automovil.Modelo,
            Automovil.año,
            Marcas.Marca,
            Mecanico.Nombre as 'Mecanico',
            Fecha_Entra,
            DescripcionFalla
            FROM
            Conexion
            INNER JOIN Cliente on (Conexion.Client = Cliente.id_cliente)
            INNER JOIN Automovil on (Conexion.Aut = Automovil.id_Auto)
            INNER JOIN Marcas on (Conexion.Marc = Marcas.id_marca)
            INNER JOIN Mecanico on (Conexion.Mecanic = Mecanico.id_Tecnico)";
            reader = com.ExecuteReader();
            return reader;
        }
    }
}
