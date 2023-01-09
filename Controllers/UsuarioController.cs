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
    public class UsuarioController : Controller
    {

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View();
        }



        public IActionResult Cadastrar()
        {

            return View();
        }

        [HttpPost]

        public IActionResult Cadastrar(Usuario us)
        {
            if (HttpContext.Session.GetString("idUsuario") == null)
            {
                UsuarioRepository uservar = new UsuarioRepository();
                uservar.Inserir(us);
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("AcessoN", "Acesso");
            }

        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Login(Usuario u)
        {
            if (HttpContext.Session.GetInt32("idUsuario") != 1)
            {
                UsuarioRepository ur = new UsuarioRepository();
                Usuario usuario = ur.QueryLogin(u);
                if (usuario != null)
                {
                    HttpContext.Session.SetInt32("idUsuario", usuario.idUsuario);
                    HttpContext.Session.SetString("nomeUsuario", usuario.nome);
                    return RedirectToAction("ListaPacotes", "Pacotes");
                }
                else
                {
                     ViewBag.Mensagem = "Falha no Login";
                    return View();
                   

                }
            }
            else
            {
                return RedirectToAction("AcessoN", "Acesso");
            }

        }


    }
}