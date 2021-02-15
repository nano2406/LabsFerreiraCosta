using LabsFerreiraCosta.Models;
using LabsFerreiraCosta.Models.Pst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace LabsFerreiraCosta.Controllers.Usuario{

/* File History
 * --------------------------------------------------------------------
 * Created by : Luciano Filho
 * Date       : 14/02/2021
 * Purpose    : Criação da Controller do Usuário
 * --------------------------------------------------------------------
 */

    public class UsuarioController : Controller{

        private UsuarioPst _Usuario;

        #region Get
        
        [HttpGet]
        public ActionResult Pesquisar(int? pagina, string nome, string cpf, string login, string status) {
            int tamPagina = 10;
            int numPag = pagina ?? 1;
            _Usuario = new UsuarioPst();
            ModelState.Clear();
            if (!String.IsNullOrEmpty(nome)) {
                return View(_Usuario.Pesquisar(nome, cpf, login, status).ToPagedList(numPag, tamPagina));
            }

            return View(_Usuario.Pesquisar(nome,cpf,login,status).ToPagedList(numPag, tamPagina));
        }

        [HttpGet]
        public ActionResult Incluir() {
            return View();
        }

        [HttpGet]
        public ActionResult ValidarLogin() {
            return View();
        }



        [HttpGet]
        public ActionResult Alterar(int id ) {
            _Usuario = new UsuarioPst();

            return View(_Usuario.Pesquisar().Find(U => U.Id == id));
        }

        public ActionResult Excluir(int id) {
            try {
                _Usuario = new UsuarioPst();

                if (_Usuario.Excluir(id)) {
                    ViewBag.mensagem = "Usuário removido com Sucesso";
                }
                return RedirectToAction("Pesquisar");
            } catch (Exception) {

                return RedirectToAction("Pesquisar");
            }
           
        }

        #endregion

        #region Post

        [HttpPost]
        public ActionResult Incluir(UsuarioMdl usuario) {
            try {
                if (ModelState.IsValid) {
                    _Usuario = new UsuarioPst();
                    if (_Usuario.Incluir(usuario)) {
                        ViewBag.Mensagem = "Usuário cadastrado com sucesso";  
                    }
                }
                return View();
            } catch (Exception) {
                return RedirectToAction("Pesquisar");
            }
        }

        [HttpPost]
        public ActionResult Alterar(int id, UsuarioMdl usuario) {
            try {
                _Usuario = new UsuarioPst();
                _Usuario.Alterar(usuario);
                return RedirectToAction("Pesquisar");
            }catch (Exception) {
                return RedirectToAction("Pesquisar");
            }
        }

        [HttpPost]
        public ActionResult ValidarLogin(string login, string senha) {
            try {
                _Usuario = new UsuarioPst();
                if (_Usuario.Validar(login, senha)) {
                    return RedirectToAction("Pesquisar");

                } else {
                    return View("Validarlogin");
                }

            } catch (Exception) {
                return View("Validarlogin");
            }
        }

        #endregion
    }
}