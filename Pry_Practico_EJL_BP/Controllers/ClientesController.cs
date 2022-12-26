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
    public class ClientesController : ControllerBase
    {

        [HttpGet]
        public List<Clientes> Lista()
        {
            return ClientesData.Listar();
        }


        [HttpPost]
        public bool Insert([FromBody] Clientes oClientes)
        {
            return ClientesData.Registrar(oClientes);
        }

        [HttpGet]
        public Clientes Recuperar(int Id)
        {
            return ClientesData.Obtener(Id);
        }

        [HttpPut]
        public bool Update([FromBody] Clientes oClientes)
        {
            return ClientesData.Actualizar(oClientes);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public bool Delete(int Id)
        {
            return ClientesData.Eliminar(Id);
        }
    }
}
