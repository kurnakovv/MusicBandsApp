using MusicianBandsApp.Models;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MusicianBandsApp.Controllers
{
    public class BandsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public async Task<ActionResult> Index()
        {
            return View(await db.Bands.ToListAsync());
        }

        public ActionResult DetailsBand(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = db.Bands.Include(b => b.Musicians).FirstOrDefault(b => b.BandId == id);
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        public ActionResult CreateBand()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateBand([Bind(Include = "BandId,BandName,BandDateOfCreation,BandCountry,BandGenre,BandImage")] Band band, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                AddImage(band, imageFile);

                db.Bands.Add(band);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(band);
        }

        public async Task<ActionResult> EditBand(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = await db.Bands.FindAsync(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditBand([Bind(Include = "BandId,BandName,BandDateOfCreation,BandCountry,BandGenre,BandImage")] Band band, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                AddImage(band, imageFile);

                db.Entry(band).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(band);
        }

        public async Task<ActionResult> DeleteBand(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = await db.Bands.FindAsync(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedBand(int id)
        {
            Band band = await db.Bands.FindAsync(id);
            db.Bands.Remove(band);
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

        private void AddImage(Band band, HttpPostedFileBase imageFile)
        {
            if (imageFile != null)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var directoryToSave = Server.MapPath(Url.Content("~/img"));

                var pathToSave = Path.Combine(directoryToSave, fileName);
                imageFile.SaveAs(pathToSave);
                band.BandImage = fileName;
            }
        }
    }
}
