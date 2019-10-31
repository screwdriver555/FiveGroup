using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FiveGroup.Models;

namespace FiveGroup.Controllers
{
    public class DoctorController : Controller
    {
        Project2Entities db = new Project2Entities();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.doctor.ToList());
        }

        public ActionResult Create()
        {
            /*取資料筆數並呼叫New_Doc_id獲取新id，再透過ViewBag傳至前端*/
            var c = db.doctor.Count();
            string id;
            id = New_Doc_id(c);
            ViewBag.doc_id = id;
           /************************************************************/
            return View();
        }

        [HttpPost]
        public ActionResult Create(doctor doctor)
        {
            db.doctor.Add(doctor);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            var doctor = db.doctor.Where(m => m.doc_id == id).FirstOrDefault();
            return View(doctor);
        }
        [HttpPost]
        public ActionResult Edit(string doc_id, string doc_name, string doc_history, Boolean doc_display)
        {
            var doctor = db.doctor.Where(m => m.doc_id == doc_id).FirstOrDefault();
            doctor.doc_id = doc_id;
            doctor.doc_name = doc_name;
            doctor.doc_history = doc_history;
            doctor.doc_display = doc_display;

            db.SaveChanges();

            return RedirectToAction("Index");
        }


        //public ActionResult Delete(string id)
        //{
        //    var doctor = db.doctor.Where(m => m.doc_id == id).FirstOrDefault();
        //    db.doctor.Remove(doctor);
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        /*********************************************************/
        /******************此為測試New_Doc_id程式*****************/
        //public void Cte()
        //{
        //    var c = db.doctor.Count();
        //    String i;
        //    i=New_Doc_id(c);
        //    Response.Write(i);
        //}
        /*********************************************************/
        /********************************************************/

        public string New_Doc_id(int id)
        {
            string Doc_id,h;
            id++;
            if (id < 10)
            {
                h = Convert.ToString(id);/*將id轉換為字串*/
                Doc_id = "DR00" + id;
            }
            else if (id >= 10 && id < 100)
            {
                h = Convert.ToString(id);
                Doc_id = "DR0" + id;
            }
            else {
                h = Convert.ToString(id);
                Doc_id = "DR" + id;
            }
            return Doc_id;
        }

    }
}