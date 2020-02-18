using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockMusicMasters.Models
{
    public class OtherTag : ITag
    {
        [Key]
        public int ID { get; set; }

        public string Tag { get; set; }

        public virtual ICollection<MusicTrackOtherTag> MusicTrackOtherTags { get; set; }
    }
}