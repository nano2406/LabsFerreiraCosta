using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabsFerreiraCosta.Controllers{

/* File History
 * --------------------------------------------------------------------
 * Created by : Luciano Filho
 * Date       : 15/02/2021
 * Purpose    : Criação da Controller do Usuário
 * --------------------------------------------------------------------
 */

    public class RelatorioController : Controller
    {
        // GET: Relatorio
        public ActionResult Index()
        {
            return View("~/Views/Relatorio/Relatorio.cshtml");
        }
    }
}