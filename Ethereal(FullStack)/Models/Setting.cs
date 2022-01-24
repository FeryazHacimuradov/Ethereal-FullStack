using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ethereal_FullStack_.Models
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string Logo { get; set; }
        [MaxLength(150), Required]
        public string Title { get; set; }
        [MaxLength(250), Required]
        public string SubTitle { get; set; }
        [MaxLength(250), Required]
        public string Address { get; set; }
        [MaxLength(150), Required]
        public string Email { get; set; }
        [MaxLength(50), Required]
        public string Phone { get; set; }
    }
}
