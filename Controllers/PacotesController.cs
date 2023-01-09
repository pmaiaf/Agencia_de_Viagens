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
    public class PacotesController : Controller
    {

        public IActionResult Cadastrar()
        {
            if (HttpContext.Session.GetString("idUsuario") != null)
            {
                return View();
            }
            else
            {

                return RedirectToAction("AcessoN", "Acesso");
            }

        }

        [HttpPost]

        public IActionResult Cadastrar(Pacotes pc)
        {
            PacotesRepository pr = new PacotesRepository();

            pc.idUsuarios = (int)HttpContext.Session.GetInt32("idUsuario");
            pr.Inserir(pc);
            return RedirectToAction("ListaPacotes");
        }
        public IActionResult ListaProUser()
        {
            if(HttpContext.Session.GetString("idUsuario") == null)
            {
                PacotesRepository pr = new PacotesRepository();
                return View(pr.Ler());
            }
            else
            {
                  return RedirectToAction("AcessoN", "Acesso");
            }

        }

        public IActionResult ListaPacotes()
        {
            if (HttpContext.Session.GetString("idUsuario") != null)
            {
                PacotesRepository pr = new PacotesRepository();
                return View(pr.Ler());
            }
            else
            {
                return RedirectToAction("AcessoN", "Acesso");
            }

        }

        public IActionResult Editar(int id)
        {
            PacotesRepository pr = new PacotesRepository();
            return View(pr.BuscarId(id));
        }
        [HttpPost]

        public IActionResult Editar(Pacotes pc)
        {
            PacotesRepository pr = new PacotesRepository();
            pr.Editar(pc);
            return RedirectToAction("ListaPacotes");
        }

        public IActionResult Deletar(int id)
        {
            PacotesRepository pr = new PacotesRepository();
            pr.Deletar(id);
            return RedirectToAction("ListaPacotes");
        }
    }

}
