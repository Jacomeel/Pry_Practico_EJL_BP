using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pry_Practico_EJL_BP.Data;
using Pry_Practico_EJL_BP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pry_Practico_EJL_BP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {

        [HttpGet]
        public List<Cuentas> Lista()
        {
            return CuentasData.Listar();
        }

        [HttpPost]
        public bool Insert([FromBody] Cuentas oCuentas)
        {
            return CuentasData.Registrar(oCuentas);
        }

        [HttpPut]
        public bool Update([FromBody] Cuentas oCuentas)
        {
            return CuentasData.Actualizar(oCuentas);
        }

        [HttpGet]
        public Cuentas Recuperar(int Id)
        {
            return CuentasData.Obtener(Id);
        }

        [HttpDelete]
        public bool Delete(int Id)
        {
            return CuentasData.Eliminar(Id);
        }

    }
}
