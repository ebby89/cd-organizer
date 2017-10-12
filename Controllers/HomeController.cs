using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using CDOrganizer.Models;

namespace CDOrganizer.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("/artists")]
        public ActionResult Artists()
        {
          List<Artist> allArtists = Artist.GetAll();
          return View(allArtists);
        }

        [HttpGet("/artists/new")]
        public ActionResult ArtistForm()
        {
          return View();
        }

        [HttpPost("/artists")]
        public ActionResult AddArtist()
        {
          Artist newArtist = new Artist(Request.Form["artist-name"]);
          List<Artist> allArtists = Artist.GetAll();
          return View("Artists", allArtists);
        }

        [HttpGet("/artists/{id}")]
        public ActionResult ArtistDetail(int id)
        {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Artist selectedArtist = Artist.Find(id);
          List<CD> artistCDs = selectedArtist.GetCDs();
          model.Add("artist", selectedArtist);
          model.Add("cds", artistCDs);
          return View(model);
        }

        [HttpGet("/artists/{id}/cds/new")]
        public ActionResult ArtistCDForm(int id)
        {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Artist selectedArtist = Artist.Find(id);
          List<CD> artistCDs = selectedArtist.GetCDs();
          model.Add("artist", selectedArtist);
          model.Add("cds", artistCDs);
          return View(model);
        }

        [HttpPost("/cds")]
        public ActionResult AddCD()
        {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Artist selectedArtist = Artist.Find(Int32.Parse(Request.Form["artist-id"]));
          List<CD> artistCDs = selectedArtist.GetCDs();
          string CDalbumName = Request.Form["cd-albumName"];
          int CDYear = (Int32.Parse(Request.Form["cd-year"]));
          CD newCD = new CD(CDalbumName, CDYear);
          artistCDs.Add(newCD);
          model.Add("cds", artistCDs);
          model.Add("artist", selectedArtist);
          return View("ArtistDetail", model);
        }

        [HttpGet("/cds/{id}")]
        public ActionResult CDDetail(int id)
        {
          CD cd = CD.Find(id);
          return View(cd);
        }
    }
}
