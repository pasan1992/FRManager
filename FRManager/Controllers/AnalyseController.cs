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
        private MainDBContext db1 = new MainDBContext();
       
        // GET: /Analyse/
        public ActionResult Index()
        {
            return View(db1.Message.ToList());
        }

        // GET: /Analyse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageDataModel dyanamicdatamodel = db1.Message.Find(id);
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
        public ActionResult Create([Bind(Include="mac,user_name,cpu_usage,memory_usage,disk_free_space,record_date")] MessageDataModel dyanamicdatamodel)
        {
            if (ModelState.IsValid)
            {
                db1.Message.Add(dyanamicdatamodel);
                db1.SaveChanges();
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
            MessageDataModel dyanamicdatamodel = db1.Message.Find(id);
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
        public ActionResult Edit([Bind(Include="mac,user_name,cpu_usage,memory_usage,disk_free_space,record_date")] MessageDataModel dyanamicdatamodel)
        {
            if (ModelState.IsValid)
            {
                db1.Entry(dyanamicdatamodel).State = EntityState.Modified;
                db1.SaveChanges();
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
            MessageDataModel dyanamicdatamodel = db1.Message.Find(id);
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
            MessageDataModel dyanamicdatamodel = db1.Message.Find(id);
            db1.Message.Remove(dyanamicdatamodel);
            db1.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db1.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult currentCPU()
        {
            MessageDataModel cpuResult = db1.Message.Find(1);
            if (cpuResult == null)
            {
                return HttpNotFound();
            }
            return View(cpuResult);
          
        }


        public ActionResult CheckGraphs()
        {
            MessageDataModel cpuResult = db1.Message.Find(1);
            if (cpuResult == null)
            {
                return HttpNotFound();
            }

         
            return View(cpuResult);

        }




   [HttpPost]
        public ActionResult CheckGraphs(int id)
        {
            MessageDataModel cpuResult = db1.Message.Find(id);
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


//   public PartialViewResult view1(int ID)
//   {
//       var user = db1.Message.Where(m => m.user_name.Contains(ID));
//;       return PartialView("_showCPU",user);
//   }

   

   //computer view controller
   public ActionResult computerView(string id)
   {
       MessageDataModel cpuResult = db1.Message.Find(id);
       if (cpuResult == null)
       {
           return HttpNotFound();
       }

       //if (Request.IsAjaxRequest())
       //{
       //    return PartialView("Partial1", cpuResult);

       //}
       return View(cpuResult);
   }


   public PartialViewResult cpuPartialView(string ID)
   {
       DateTime now = DateTime.Now;
       MessageDataModel cpuResult = db1.Message.Find(ID,now);
       return PartialView("_CurrentCPU", cpuResult);
   }

   public PartialViewResult memoryPartialView(string ID)
   {
       DateTime now = DateTime.Now;
       MessageDataModel cpuResult = db1.Message.Find(ID,now);
       return PartialView("_CurrentMEM", cpuResult);
   }

   public PartialViewResult diskPartialView(string ID)
   {
       DateTime now = DateTime.Now;
       MessageDataModel cpuResult = db1.Message.Find(ID);
       return PartialView("_CurrentDISK", cpuResult);
   }



    }
}
