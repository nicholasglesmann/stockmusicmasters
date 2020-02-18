using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MimeKit;
using StockMusicMasters.Data;
using StockMusicMasters.Models;

namespace StockMusicMasters.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IMusicRepository musicRepo;
        IWebHostEnvironment _hostingEnvironment;


        public HomeController(IMusicRepository musicRepo, ILogger<HomeController> logger, 
                              IWebHostEnvironment hostingEnvironment)
        {
            this.musicRepo = musicRepo;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            // get the list of moods and store it in viewdata for music view

            ViewData["allMoods"] = musicRepo.MoodList;
            ViewData["allInstruments"] = musicRepo.InstrumentList;
            ViewData["allGenres"] = musicRepo.GenreList;

            musicRepo.CurrentMood = "";
            musicRepo.CurrentInstrument = "";
            musicRepo.CurrentGenre = "";

            return View();
        }

        [Route("music")]
        public IActionResult Music()
        {
            // get the list of moods and store it in viewdata for music view
            ViewData["allMoods"] = musicRepo.MoodList;
            ViewData["allInstruments"] = musicRepo.InstrumentList;
            ViewData["allGenres"] = musicRepo.GenreList;

            List<MusicTrack> currentMusicTracks = musicRepo.MusicTracks;

            if (musicRepo.CurrentMood != "")
            {
                currentMusicTracks = musicRepo.GetMusicTracksByMood(currentMusicTracks, musicRepo.CurrentMood);
            }

            if (musicRepo.CurrentInstrument != "")
            {
                currentMusicTracks = musicRepo.GetMusicTracksByInstrument(currentMusicTracks, musicRepo.CurrentInstrument);
            }

            if (musicRepo.CurrentGenre != "")
            {
                currentMusicTracks = musicRepo.GetMusicTracksByGenre(currentMusicTracks, musicRepo.CurrentGenre);
            }

            ViewBag.currentMood = musicRepo.CurrentMood;

            ViewBag.currentInstrument = musicRepo.CurrentInstrument;

            ViewBag.currentGenre = musicRepo.CurrentGenre;

            return View(currentMusicTracks);
        }

        public RedirectToActionResult MoodSelected(string id)
        {
            musicRepo.CurrentMood = id;
            return RedirectToAction("Music");
        }

        public RedirectToActionResult InstrumentSelected(string id)
        {
            musicRepo.CurrentInstrument = id;
            return RedirectToAction("Music");
        }

        public RedirectToActionResult GenreSelected(string id)
        {
            musicRepo.CurrentGenre = id;
            return RedirectToAction("Music");
        }

        public RedirectToActionResult ClearFilters()
        {
            musicRepo.CurrentMood = "";
            musicRepo.CurrentInstrument = "";
            musicRepo.CurrentGenre = "";
            return RedirectToAction("Music");
        }

        [HttpPost]
        public PhysicalFileResult Download(string fileName)
        {
            return GetFile(fileName);
        }

        [HttpPost]
        public FileResult Download2(string fileName)
        {
            return GetFile(fileName);
        }

        public PhysicalFileResult GetFile(string fileName)
        {

            string filePath = _hostingEnvironment.WebRootPath + "\\files\\musictracks\\" + fileName;

            return PhysicalFile(filePath, MimeTypes.GetMimeType(filePath), Path.GetFileName(filePath));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/test")]
        public IActionResult HomeTest()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
