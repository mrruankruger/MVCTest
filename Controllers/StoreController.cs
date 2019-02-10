using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTest.Models;
using System.Data.Sql;
using System.Data;
using System.Data.Entity;

namespace MVCTest.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        //GET : Store
        public ActionResult Index()
        {
            //return "Hello from Store.Index()";
            //var genres = new List<Genre>
            //{
            //    new Genre { Name = "Disco"},
            //    new Genre { Name = "Rock"},
            //    new Genre { Name = "Jazz"}
            //};
            var genres = storeDB.Genres.ToList();
            return View(genres);

        }

        //GET : Store/Browse?genre=Disco
        public ActionResult Browse(string genre)
        {
            //string message = HttpUtility.HtmlEncode("Store.Browse, Genre = " + genre);
            //return message;
            var genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name == genre);
            return View(genreModel);
        }

        //GET : Store/Details/5
        public ActionResult Details(int id)
        {
            var album = storeDB.Albums.Find(id);
            return View(album);
        }

        //
        // GET: /Store/GenreMenu
        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = storeDB.Genres.ToList();
            return PartialView(genres);
        }
    }
}