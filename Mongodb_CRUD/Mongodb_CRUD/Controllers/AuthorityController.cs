using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mongodb_CRUD.Controllers
{
    public class AuthorityController : Controller
    {
        // GET: Authority
        public ActionResult Index()
        {
            return View();
        }

        // GET: Authority/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Authority/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authority/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Authority/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Authority/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Authority/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Authority/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
