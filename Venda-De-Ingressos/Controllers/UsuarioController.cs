using Microsoft.AspNetCore.Mvc;

namespace Venda_De_Ingressos.Controllers {
    public class UsuarioController : Controller {
        // GET
        public IActionResult Index() {
            return View();
        }
    }
}