using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace URLShortner.Models
{
    public class URLDetails
    {
        public int Id { get; set; }

        [Required]
        public string LongURL { get; set; }
        public string  ShortURL{ get; set; }
        public DateTime CreatedDate{ get; set; }
    }
}