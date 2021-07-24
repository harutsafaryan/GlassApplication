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

        public byte Thickness { get; set; }
        public ushort Width { get; set; }
        public ushort Height { get; set; }

        [MaxLength(30)]
        public string GlassDescription { get; set; }
    }
}
