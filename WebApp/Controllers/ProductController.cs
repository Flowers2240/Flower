using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private ProductContext db = new ProductContext();
        // GET: flowers
        public ActionResult Index()
        {
            return View(db.products.ToList());
        }
        // GET: flowers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product flower = db.products.Find(id);
            if (flower == null)
            {
                return HttpNotFound();
            }
            return View(flower);
        }
        // GET: flowers/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: flowers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product_id,Product_name,Product_image,Product_desciption,Product_color,Product_type,Product_price,Product_amount")] Product flower)
        {
            if (ModelState.IsValid)
            {
                db.products.Add(flower);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flower);
        }
        // GET: flowers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product flower = db.products.Find(id);
            if (flower == null)
            {
                return HttpNotFound();
            }
            return View(flower);
        }
        // POST: flowers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Product_id,Product_name,Product_image,Product_desciption,Product_color,Product_type,Product_price,Product_amount")] Product flower)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flower).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flower);
        }
        // GET: flowers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product flower = db.products.Find(id);
            if (flower == null)
            {
                return HttpNotFound();
            }
            return View(flower);
        }
        // POST: flowers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product flower = db.products.Find(id);
            db.products.Remove(flower);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}