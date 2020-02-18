using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMusicMasters.Models
{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
