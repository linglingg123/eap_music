using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAP_MUSIC.Models
{
    public class Album
    {
        //[ScaffoldColumn(false)]
        public int AlbumId { get; set; }
        //[Required]
        //[StringLength(30, MinimumLength = 3)]
        public string Title { get; set; }
        //[Required]
        public System.DateTime ReleaseDate { get; set; }
        //[Required]
        public string Artist { get; set; }
        //[Required]
        //[Range(1, 15)]
        public double Price { get; set; }
        //[ScaffoldColumn(false)]
        public int GenreId { get; set; }
        //[Newtonsoft.Json.JsonIgnore]
        public virtual Genre Genre { get; set; }
    }
}