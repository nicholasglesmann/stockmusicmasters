using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockMusicMasters.Models
{
    public class SongViewModel
    {
        [Required]
        public string SongName { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string[] Genres { get; set; }

        [Required]
        public string[] Moods { get; set; }

        [Required]
        public string[] Instruments { get; set; }
    }
}
