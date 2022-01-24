using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ethereal_FullStack_.Models
{
    public class Detail
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100), Required]
        public string Title { get; set; }
        [MaxLength(150), Required]
        public string Contetnt { get; set; }
        [MaxLength(50), Required]
        public string Icon { get; set; }
    }
}
