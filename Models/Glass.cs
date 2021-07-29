using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GlassApplication.Models
{
    [Table("Glasses")]
    public class Glass
    {
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Range(4, 19, ErrorMessage ="Thikness must be 4mm - 19mm")]
        public byte Thickness { get; set; }

        [Range(100, 3210, ErrorMessage = "Width must be 100mm - 3210mm")]
        public ushort Width { get; set; }
        
        [Range(100, 6000, ErrorMessage = "Height must be 100mm - 6000mm")]
        public ushort Height { get; set; }

        [MaxLength(30)]
        public string GlassDescription { get; set; }
    }
}
