using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockMusicMasters.Models
{
    public class Rating
    {
        [ForeignKey("MusicTrack"), Column(Order = 0)]
        public int MusicTrackID { get; set; }

        [ForeignKey("AppUser"), Column(Order = 1)]
        public string UserID { get; set; }

        public MusicTrack MusicTrack { get; set; }
        public virtual AppUser AppUser { get; set; }
        public int RatingValue { get; set; }
    }
}