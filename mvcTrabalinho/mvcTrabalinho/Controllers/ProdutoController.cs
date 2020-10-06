using mvcTrabalinho.Context;
using mvcTrabalinho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcTrabalinho.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly Contexto db = new Contexto();

        // GET: Produto
        public ActionResult Index()
        {
            return View(db.produtos.ToList());
        }

        // Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoModel produto)
        {
            if (ModelState.IsValid)
            {
                db.produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // Detalhes
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            ProdutoModel prodt = db.produtos.Find(id);

            if (prodt == null)
            {
                return HttpNotFound();
            }

            return View(prodt);
        }

        // Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            ProdutoModel produts = db.produtos.Find(id);
            if (produts == null)
            {
                return HttpNotFound();
            }
            return View(produts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoModel produts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produts).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(produts);
        }

        // Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            ProdutoModel product = db.produtos.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            ProdutoModel produto = db.produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            db.produtos.Remove(produto);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}