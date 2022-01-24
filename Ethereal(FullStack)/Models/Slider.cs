using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ethereal_FullStack_.Models
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(500), Required]
        public string Contetnt { get; set; }
        [MaxLength(150), Required]
        public string FullName { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
