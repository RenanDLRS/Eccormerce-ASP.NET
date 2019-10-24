using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.DAL;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoDAO _produtoDAO;
        
        public ProdutoController(ProdutoDAO produtoDAO)
        {
            _produtoDAO = produtoDAO;
        }

        //Métodos dos controlers são chamados de actions
        public IActionResult Index()
        {
            ViewBag.DataHora = DateTime.Now;

            return View(_produtoDAO.Listar());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                if (_produtoDAO.CadastrarProduto(produto))
                {
                    return RedirectToAction("Index");

                }
                ModelState.AddModelError("", "Produto já cadastrado");

                return View();
            }
            return View(produto);
        }

        public IActionResult Remover(int? Id)
        {
            if (Id != null)
            {
                _produtoDAO.Remover(Id);
            }
            else
            {
                //redirecionar para uma pagina de erro
            }


            return RedirectToAction("Index");
        }
        public IActionResult Alterar(int? Id)
        {
            Produto p = _produtoDAO.BuscarPorId(Id);
            if (p != null)
            {
                return View(p);
            }
            else
            {
                return View();
                //redirecionar para uma pagina de erro
            }


        }
        [HttpPost]
        public IActionResult Alterar(Produto produto)
        {
            _produtoDAO.Alterar(produto);

            return RedirectToAction("Index");
        }
    }
}