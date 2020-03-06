using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Venda_De_Ingressos.Models;

namespace Venda_De_Ingressos.Controllers {
    [Route("api/[controller]")] [ApiController]
    public class ClientesController : ControllerBase {
        [Authorize] [HttpGet] public IActionResult GetClientes() {
            List<Cliente> clientes = new List<Cliente>();
            clientes.Add
            (new Cliente() {
                ClienteId = 1, Nome = "Macoratti", Email = "macoratti@yahoo.com"
            });
            clientes.Add
            (new Cliente() {
                ClienteId = 2, Nome = "Andre Lima", Email = "andrelima@uol.com.br"
            });
            clientes.Add
            (new Cliente() {
                ClienteId = 3, Nome = "Janete Siqueira", Email = "jansiqueira@hotmail.com"
            });
            return new ObjectResult(clientes);
        }
    }
}