using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicianBandsApp.Models;
using System.IO;

namespace MusicianBandsApp.Controllers
{
    public class MusiciansController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public async Task<ActionResult> Index()
        {
            var musicians = db.Musicians.Include(m => m.Band);
            return View(await musicians.ToListAsync());
        }

        public async Task<ActionResult> DetailsMusician(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musician musician = await db.Musicians.FindAsync(id);
            if (musician == null)
            {
                return HttpNotFound();
            }
            return View(musician);
        }

        public ActionResult CreateMusician()
        {
            ViewBag.BandId = new SelectList(db.Bands, "BandId", "BandName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateMusician([Bind(Include = "MusicianId,MusicianName,MusicianDateOfBirth,MusicianRole,MusicianImage,BandId")] Musician musician, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                AddImage(musician, imageFile);

                db.Musicians.Add(musician);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewBag.BandId = new SelectList(db.Bands, "BandId", "BandName", musician.BandId);
            return View(musician);
        }

        public async Task<ActionResult> EditMusician(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musician musician = await db.Musicians.FindAsync(id);
            if (musician == null)
            {
                return HttpNotFound();
            }
            ViewBag.BandId = new SelectList(db.Bands, "BandId", "BandName", musician.BandId);
            return View(musician);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditMusician([Bind(Include = "MusicianId,MusicianName,MusicianDateOfBirth,MusicianRole,MusicianImage,BandId")] Musician musician, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                AddImage(musician, imageFile);

                db.Entry(musician).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            ViewBag.BandId = new SelectList(db.Bands, "BandId", "BandName", musician.BandId);
            return View(musician);
        }

        public async Task<ActionResult> DeleteMusician(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musician musician = await db.Musicians.FindAsync(id);
            if (musician == null)
            {
                return HttpNotFound();
            }
            return View(musician);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedMusician(int id)
        {
            Musician musician = await db.Musicians.FindAsync(id);
            db.Musicians.Remove(musician);
            await db.SaveChangesAsync();
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

        private void AddImage(Musician musician, HttpPostedFileBase imageFile)
        {
            if (imageFile != null)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var directoryToSave = Server.MapPath(Url.Content("~/img"));

                var pathToSave = Path.Combine(directoryToSave, fileName);
                imageFile.SaveAs(pathToSave);
                musician.MusicianImage = fileName;
            }
        }
    }
}
