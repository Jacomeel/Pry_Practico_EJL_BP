using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pry_Practico_EJL_BP.Models
{
    public class Cuentas
    {
        [Key]
        public Int32 NumCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public string SaldoInicial { get; set; }
        public string Estado { get; set; }
        public string Cliente { get; set; }
    }
}
