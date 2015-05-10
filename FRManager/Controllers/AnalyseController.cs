using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FRManager.Models;

namespace FRManager.Controllers
{
    public class AnalyseController : Controller
    {
        private DynamicDBContext db = new DynamicDBContext();

        // GET: /Analyse/
        public ActionResult Index()
        {
            return View(db.DynamicDatabase.ToList());
        }

        // GET: /Analyse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DyanamicDataModel dyanamicdatamodel = db.DynamicDatabase.Find(id);
            if (dyanamicdatamodel == null)
            {
                return HttpNotFound();
            }
            return View(dyanamicdatamodel);
        }

        // GET: /Analyse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Analyse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="mac,user_name,cpu_usage,memory_usage,disk_free_space,record_date")] DyanamicDataModel dyanamicdatamodel)
        {
            if (ModelState.IsValid)
            {
                db.DynamicDatabase.Add(dyanamicdatamodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dyanamicdatamodel);
        }

        // GET: /Analyse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DyanamicDataModel dyanamicdatamodel = db.DynamicDatabase.Find(id);
            if (dyanamicdatamodel == null)
            {
                return HttpNotFound();
            }
            return View(dyanamicdatamodel);
        }

        // POST: /Analyse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="mac,user_name,cpu_usage,memory_usage,disk_free_space,record_date")] DyanamicDataModel dyanamicdatamodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dyanamicdatamodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dyanamicdatamodel);
        }

        // GET: /Analyse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DyanamicDataModel dyanamicdatamodel = db.DynamicDatabase.Find(id);
            if (dyanamicdatamodel == null)
            {
                return HttpNotFound();
            }
            return View(dyanamicdatamodel);
        }

        // POST: /Analyse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DyanamicDataModel dyanamicdatamodel = db.DynamicDatabase.Find(id);
            db.DynamicDatabase.Remove(dyanamicdatamodel);
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

        public ActionResult currentCPU()
        {
            DyanamicDataModel cpuResult = db.DynamicDatabase.Find(1);
            if (cpuResult == null)
            {
                return HttpNotFound();
            }
            return View(cpuResult);
          
        }


        public ActionResult CheckGraphs()
        {
            DyanamicDataModel cpuResult = db.DynamicDatabase.Find(1);
            if (cpuResult == null)
            {
                return HttpNotFound();
            }

         
            return View(cpuResult);

        }




   [HttpPost]
        public ActionResult CheckGraphs(int id)
        {
            DyanamicDataModel cpuResult = db.DynamicDatabase.Find(id);
            if (cpuResult == null)
            {
                return HttpNotFound();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_showCPU", cpuResult);

            }
            return View(cpuResult);

        }


   public PartialViewResult view1(string ID)
   {
        var user = db.DynamicDatabase.Where(m => m.user_name.Contains(ID));
;       return PartialView("_showCPU",user);
   }
      





    }
}
