using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using att_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace att_2.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController (ILogger<HomeController> logger) {
            _logger = logger;
        }

// mudei essa parte
        Noticias noticiasModel = new Noticias ();
        public IActionResult Index () {
            ViewBag.Noticias = noticiasModel.ReadAll ();
            return View ();
        }

        //funcionou mas nao está meio esticado
        //puxo os dados da model do noticias para a view da home

// tentei fazer com que os models venha para a view da home tbm
        public IActionResult Privacy () {
            return View ();
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}