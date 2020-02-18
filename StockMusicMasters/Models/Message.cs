using System;
using System.ComponentModel.DataAnnotations;

namespace StockMusicMasters.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        // properties
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string MessageTitle { get; set; }

        public string MessageBody { get; set; }
    }
}
