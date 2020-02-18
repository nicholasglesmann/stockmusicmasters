using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockMusicMasters.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        public int FK_MusicTrackID { get; set; }

        [ForeignKey("FK_MusicTrackID")]
        public MusicTrack MusicTrack { get; set; }
        public string CommentText { get; set; }
    }
}