using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Atividade_02OFC.Models;
using Microsoft.AspNetCore.Http;


namespace Atividade_02OFC.Controllers
{
    public class Acesso : Controller
    {

        public IActionResult AcessoN()
        {
            return View();
        }


    }
}