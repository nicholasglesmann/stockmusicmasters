using Microsoft.AspNetCore.Mvc;
using StockMusicMasters.Api;
using StockMusicMasters.Data;
using StockMusicMasters.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StockMusicMasters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsApiController : ControllerBase
    {
        IMusicRepository repo;

        public StatsApiController(IMusicRepository r)
        {
            repo = r;
        }

        [Route("/api/gettotalsongsbygenre")]
        public IActionResult GetTotalSongsByGenre()
        {
            var tracks = repo.MusicTracks
                             .GroupBy(m => m.Genre)
                             .Select(g => new MusicTrackGrouping() { Name = g.Key.Tag, Count = g.Count() })
                             .OrderBy(t => t.Name)
                             .ToList();

            if (tracks.Count() > 0)
            {
                return Ok(tracks);
            }

            return NotFound();
        }

        [Route("/api/gettotalsongsbyinstrument")]
        public IActionResult GetTotalSongsByInstrument()
        {
            var tracks = repo.MusicTrackInstrumentTags
                             .GroupBy(m => m.InstrumentTag.Tag)
                             .Select(g => new MusicTrackGrouping() { Name = g.Key, Count = g.Count() })
                             .OrderBy(t => t.Name)
                             .ToList();

            if (tracks.Count() > 0)
            {
                return Ok(tracks);
            }

            return NotFound();
        }

        [Route("/api/gettotalsongsbymood")]
        public IActionResult GetTotalSongsByMood()
        {
            var tracks = repo.MusicTrackMoodTags
                             .GroupBy(m => m.MoodTag.Tag)
                             .Select(g => new MusicTrackGrouping() { Name = g.Key, Count = g.Count() })
                             .OrderBy(t => t.Name)
                             .ToList();

            if (tracks.Count() > 0)
            {
                return Ok(tracks);
            }

            return NotFound();
        }
    }
}