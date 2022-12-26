using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pry_Practico_EJL_BP.Models
{
    public class Movimientos
    {
        [Key]
        public int IdCuenta { get; set; }
        public string Fecha { get; set; }
        public string Nombre { get; set; }
        public string NumCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public string SaldoInicial { get; set; }
        public string Estado { get; set; }
        public string Movimiento { get; set; }
        public string saldo { get; set; }
    }
}
