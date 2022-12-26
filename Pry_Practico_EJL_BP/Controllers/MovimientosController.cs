using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pry_Practico_EJL_BP.Data;
using Pry_Practico_EJL_BP.Models;

namespace Pry_Practico_EJL_BP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {

        [HttpPost]
        public string Insert([FromBody] Movimientos oMovimientos)
        {
            return MovimientosData.Registrar(oMovimientos);
        }

        [HttpGet]
        public List<Movimientos> Lista()
        {
            return MovimientosData.Listar();
        }


        [HttpGet]
        public Movimientos Recuperar(int Id,DateTime fecini,DateTime fecfin)
        {
            return MovimientosData.Obtener(Id,fecini,fecfin);
        }
    }
}
