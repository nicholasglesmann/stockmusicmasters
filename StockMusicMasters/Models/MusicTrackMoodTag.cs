using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockMusicMasters.Models
{
    public class MusicTrackMoodTag
    {
        [Key, Column(Order = 1)]
        public int MusicTrackID { get; set; }
        [Key, Column(Order = 2)]
        public int MoodTagID { get; set; }
        public MusicTrack MusicTrack { get; set; }
        public MoodTag MoodTag { get; set; }
    }
}