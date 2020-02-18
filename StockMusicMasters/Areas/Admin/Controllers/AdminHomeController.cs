using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMusicMasters.Data;
using StockMusicMasters.Models;

namespace StockMusicMasters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        IMusicRepository musicRepo;

        public AdminHomeController(IMusicRepository music)
        {
            musicRepo = music;
        }

        [Route("admin", Name="AdminIndex")]
        public IActionResult AdminIndex()
        {
            return View();
        }

        [Route("admin/manage-songs", Name="AdminManageSongs")]
        public IActionResult ManageSongs()
        {
            List<MusicTrack> allMusicTracks = musicRepo.MusicTracks;

            return View(allMusicTracks);
        }

        [Route("admin/addsong")]
        public IActionResult AddSong()
        {
            // get the list of moods and store it in viewdata for music view
            ViewData["allMoods"] = musicRepo.MoodList;
            ViewData["allInstruments"] = musicRepo.InstrumentList;
            ViewData["allGenres"] = musicRepo.GenreList;
            return View();
        }

        [Route("admin/addsong")]
        [HttpPost]
        public IActionResult AddSong(IFormCollection formCollection, string songName, string fileName)
        {
            var collection = formCollection;

            GenreTag genreTag = musicRepo.GetGenreTagFromDataBase(collection["genre"]);

            MusicTrack song = new MusicTrack();
            song.Name = songName;
            song.Genre = genreTag;
            song.FileName = fileName;

            List<MoodTag> moodTags = new List<MoodTag>();
            for (int i = 0; i <= musicRepo.MoodList.Count; i++)
            {
                string mood = "mood" + i.ToString();
                string value = collection[mood];
                if (value != null)
                {
                    MoodTag moodTag = musicRepo.GetMoodTagFromDatabase(value);
                    song.Moods.Add(moodTag);

                    var m = new MusicTrackMoodTag();
                    m.MusicTrack = song;
                    m.MoodTag = moodTag;
                    song.MusicTrackMoodTags.Add(m);
                }

                string instrument = "instrument" + i.ToString();
                value = collection[instrument];
                if (value != null)
                {
                    InstrumentTag instrumentTag = musicRepo.GetInstrumentTagFromDatabase(value);
                    song.Instruments.Add(instrumentTag);

                    var m = new MusicTrackInstrumentTag();
                    m.MusicTrack = song;
                    m.InstrumentTag = instrumentTag;
                    song.MusicTrackInstrumentTags.Add(m);
                }
            }

            musicRepo.MusicTracks.Add(song);

            musicRepo.SaveSongToDatabase(song);

            return RedirectToRoute("AdminIndex");
        }

        [Route("admin/editsong")]
        public IActionResult EditSong(int id)
        {
            // get the list of moods and store it in viewdata for music view
            ViewData["allMoods"] = musicRepo.MoodList;
            ViewData["allInstruments"] = musicRepo.InstrumentList;
            ViewData["allGenres"] = musicRepo.GenreList;

            MusicTrack song = musicRepo.GetMusicTrackById(id);
            return View(song);
        }

        [Route("admin/editsong")]
        [HttpPost]
        public IActionResult EditSong(IFormCollection formCollection, string songName, string fileName, int id)
        {
            MusicTrack song = musicRepo.GetMusicTrackById(id);

            var collection = formCollection;

            GenreTag genreTag = musicRepo.GetGenreTagFromDataBase(collection["genre"]);

            song.Name = songName;
            song.Genre = genreTag;
            song.FileName = fileName;

            List<MoodTag> moodTags = new List<MoodTag>();
            for (int i = 0; i <= musicRepo.MoodList.Count; i++)
            {
                string mood = "mood" + i.ToString();
                string value = collection[mood];
                if (value != null)
                {
                    MoodTag moodTag = musicRepo.GetMoodTagFromDatabase(value);
                    song.Moods.Add(moodTag);

                    var m = new MusicTrackMoodTag();
                    m.MusicTrack = song;
                    m.MoodTag = moodTag;
                    song.MusicTrackMoodTags.Add(m);
                }

                string instrument = "instrument" + i.ToString();
                value = collection[instrument];
                if (value != null)
                {
                    InstrumentTag instrumentTag = musicRepo.GetInstrumentTagFromDatabase(value);
                    song.Instruments.Add(instrumentTag);

                    var m = new MusicTrackInstrumentTag();
                    m.MusicTrack = song;
                    m.InstrumentTag = instrumentTag;
                    song.MusicTrackInstrumentTags.Add(m);
                }
            }

            musicRepo.MusicTracks.Add(song);

            musicRepo.SaveSongToDatabase(song);

            return RedirectToRoute("AdminIndex");
        }

        [Route("admin/delete")]
        [HttpPost]
        public IActionResult DeleteSong(int id)
        {
            MusicTrack song = musicRepo.GetMusicTrackById(id);

            musicRepo.DeleteSongFromDatabase(song);

            return RedirectToRoute("AdminManageSongs");
        }

        [Route("Admin/Test")]
        public IActionResult Test()
        {
            return View();
        }
    }
}