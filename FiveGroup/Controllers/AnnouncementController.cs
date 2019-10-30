using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FiveGroup.Models;

namespace FiveGroup.Controllers
{
    public class AnnouncementController : Controller
    {
        Project2Entities db = new Project2Entities();
        // GET: Home
        public ActionResult Index()
        {
            var anns = db.announcement.OrderBy
            (m => m.a_id).ToList();

            return View(anns);
        }



        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string a_id,DateTime a_date, string a_content, bool a_display)
        {
            announcement anns = new announcement();
            anns.a_id = a_id;
            anns.a_date = a_date;
            anns.a_content = a_content;
            anns.a_display = a_display;
            db.announcement.Add(anns);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Edit(string a_id)
        {
            var anns = db.announcement.Where
            (m => m.a_id == a_id).FirstOrDefault();
            return View(anns);
        }

        [HttpPost]
        public ActionResult Edit(string a_id,DateTime a_date, string a_content, bool a_display)
        {
            var anns = db.announcement.Where        
            (m=>m.a_id==a_id).FirstOrDefault();
            anns.a_id = a_id;
            anns.a_date = a_date;
            anns.a_content = a_content;
            anns.a_display = a_display;
            db.SaveChanges();
            return RedirectToAction("Index");






        }
        public ActionResult Delete(string a_id)       
        {

            var anns = db.announcement.Where(m => m.a_id == a_id).FirstOrDefault();
            db.announcement.Remove(anns);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
     
}