using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockMusicMasters.Models
{
    public class MoodTag : ITag
    {
        [Key]
        public int ID { get; set; }

        public string Tag { get; set; }

        public virtual ICollection<MusicTrackMoodTag> MusicTrackMoodTags { get; set; }
    }
}
