using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using mvcTrabalinho.Context;
using mvcTrabalinho.Models;

namespace mvcTrabalinho.Controllers
{
    public class PedidoController : Controller
    {
        private readonly Contexto db = new Contexto();
        // GET: Pedido
        public ActionResult Index()
        {
            var Orders = db.pedidos.Include(p => p.pproduto).ToList();
            return View(Orders);
        }

        public ActionResult Create()
        {
            ViewBag.ProdutoID = new SelectList(db.produtos, "Id", "pproduto");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoModel pedido)
        {
            if (ModelState.IsValid)
            {
                db.pedidos.Add(pedido);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ProdutoID = new SelectList(db.produtos, "Id", "pproduto");
            return View(pedido);
        }

        // DETALHES
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            PedidoModel pediduus = db.pedidos.Include(c => c.pproduto).First(a => a.Id == id);

            if (pediduus == null)
            {
                HttpNotFound();
            }

            return View(pediduus);
        }

        //Delete
        // Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            PedidoModel order = db.pedidos.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            PedidoModel order = db.pedidos.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            db.pedidos.Remove(order);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}