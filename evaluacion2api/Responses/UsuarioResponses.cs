using Microsoft.AspNetCore.Mvc;

namespace evaluacion2api.Responses
{
    public class UsuarioResponses : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
