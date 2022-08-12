using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Conexion
    {
        public int IdConexion { set; get; }
        public int Cliente { set; get; }
        public int Auto { set; get; }
        public int Marca { set; get; }
        public int Mecanico { set; get; }
        public string Fecha { set; get; }
        public string Descripcion { set; get; }
    }
}
