using System.ComponentModel.DataAnnotations;

namespace StockMusicMasters.Models
{
    public class GenreTag : ITag
    {
        [Key]
        public int GenreTagID { get; set; }

        public string Tag { get; set; }
    }
}