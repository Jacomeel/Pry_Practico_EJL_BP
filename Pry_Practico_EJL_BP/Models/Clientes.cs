using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pry_Practico_EJL_BP.Models
{
    public class Clientes
    {
        [Key]
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }  
        public string Identificación { get; set; }
        public string Dirección { get; set; }
        public string Teléfono { get; set; }
        public string Contraseña { get; set; }
        public string Estado { get; set; }

    }
}
