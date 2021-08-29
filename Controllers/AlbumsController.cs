using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EAP_MUSIC.Models;
using PagedList;

namespace EAP_MUSIC.Controllers
{
    public class AlbumsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Albums
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //var albums = db.Albums.Include(a => a.Genre);
            //return View(albums.ToList());
            ViewBag.CurrentSort = sortOrder;
            //ViewBag.SortParm = sortOrder == "OtherFind" ? "Artist" : "Genre";
            //ViewBag.TitleSortParm=sortOrder == "Title" ? "Des" : "Acs";
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "Title" : "";
            ViewBag.ArtistSortParm = String.IsNullOrEmpty(sortOrder) ? "Artist" : "";
            //ViewBag.GenreSortParm = String.IsNullOrEmpty(sortOrder) ? "Genre" : "";
            ViewBag.DateSortParm = sortOrder == "Release Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var find = from s in db.Albums
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                find = find.Where(s => s.Title.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Title":
                    find = find.OrderByDescending(s => s.Title);
                    break;
                //case "Genre":
                //    find = find.OrderByDescending(s => s.Genre);
                //    break;
                case "Artist":
                    find = find.OrderByDescending(s => s.Artist);
                    break;
                case "Date":
                    find = find.OrderBy(s => s.ReleaseDate);
                    break;
                case "date_desc":
                    find = find.OrderByDescending(s => s.ReleaseDate);
                    break;
                default:  // Name ascending 
                    find = find.OrderBy(s => s.Title);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(find.ToPagedList(pageNumber, pageSize));
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        //[Authorize]
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName");
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize]
        public ActionResult Create([Bind(Include = "AlbumId,Title,ReleaseDate,Artist,Price,GenreId")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", album.GenreId);
            return View(album);
        }

        // GET: Albums/Edit/5
        //[Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", album.GenreId);
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize]
        public ActionResult Edit([Bind(Include = "AlbumId,Title,ReleaseDate,Artist,Price,GenreId")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", album.GenreId);
            return View(album);
        }

        // GET: Albums/Delete/5
        //[Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
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
