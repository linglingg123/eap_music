using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EAP_MUSIC.Models
{
    public class Genre
    {
        //Constructor - Access Modifier
        public Genre()
        {
            this.Albums = new HashSet<Album>();
        }

        //Primary key
        public int GenreId { get; set; }
        public string GenreName { get; set; }

        //Navigate property
        public virtual ICollection<Album> Albums { get; set; }
    }
}