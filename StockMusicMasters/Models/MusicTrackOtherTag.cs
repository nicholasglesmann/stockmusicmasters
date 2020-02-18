using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockMusicMasters.Models
{
    public class MusicTrackOtherTag
    {
        [Key, Column(Order = 1)]
        public int MusicTrackID { get; set; }
        [Key, Column(Order = 2)]
        public int OtherTagID { get; set; }
        public MusicTrack MusicTrack { get; set; }
        public OtherTag OtherTag { get; set; }
    }
}