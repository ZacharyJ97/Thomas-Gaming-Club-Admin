using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Thomas_Gaming_Club.Data_Contexts;
using Thomas_Gaming_Club.Models;

namespace Thomas_Gaming_Club___Admin.Controllers
{
    public class ResourceController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: Resource
        public ActionResult Index()
        {
            return View(db.VideoGames.ToList());
        }

        // GET: Resource/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resource/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "gameId,title,year,publisher,developer,platform")] VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                db.VideoGames.Add(videoGame);
                db.SaveChanges();
                return RedirectToAction("ResourceManager");
            }

            return View(videoGame);
        }

        // GET: Resource/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return HttpNotFound();
            }
            return View(videoGame);
        }

        // POST: Resource/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "gameId,title,year,publisher,developer,platform")] VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoGame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ResourceManager");
            }
            return View(videoGame);
        }

        // GET: Resource/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return HttpNotFound();
            }
            return View(videoGame);
        }

        // POST: Resource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoGame videoGame = db.VideoGames.Find(id);
            db.VideoGames.Remove(videoGame);
            db.SaveChanges();
            return RedirectToAction("ResourceManager");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult ResourceManager()
        {
            ViewBag.VideoGames = db.VideoGames.OrderBy(x => x.Platform);
            return View();
        }

        [HttpGet]
        public ViewResult Resources()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PS4Games()
        {
            ViewBag.VideoGames = db.VideoGames.Where(x => x.Platform.Contains("PS4") || x.Platform.Contains("PSVR")).ToList().OrderBy(x => x.Title);
            return View();
        }

        [HttpGet]
        public ActionResult WiiUGames()
        {
            ViewBag.VideoGames = db.VideoGames.Where(x => x.Platform.Contains("WiiU")).ToList().OrderBy(x => x.Title);
            return View();
        }

        [HttpGet]
        public ActionResult XboxGames()
        {
            ViewBag.VideoGames = db.VideoGames.Where(x => x.Platform.Contains("Xbox")).ToList().OrderBy(x => x.Title);
            return View();
        }

        [HttpGet]
        public ActionResult PCGames()
        {
            ViewBag.VideoGames = db.VideoGames.Where(x => x.Platform.Contains("PC")).ToList().OrderBy(x => x.Title);
            return View();
        }

        [HttpGet]
        public ActionResult WiiGames()
        {
            ViewBag.VideoGames = db.VideoGames.Where(x => x.Platform.Equals("Wii")).ToList().OrderBy(x => x.Title);
            return View();
        }
    }
}
