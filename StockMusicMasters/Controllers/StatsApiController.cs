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
            var tracks = repo.MusicTracks.GroupBy(m => m.Genre)
                                    .Select(g => new MusicTrackGrouping() { Name = g.Key.Tag, Count = g.Count() })
                                    .ToList();

            //var tracks = from MusicTrack in repo.MusicTracks
            //             group MusicTrack by MusicTrack.Genre;

            if (tracks.Count() > 0)
            {
                return Ok(tracks);
            }

            return NotFound();
        }
    }
}