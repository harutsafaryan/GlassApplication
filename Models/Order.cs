using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GlassApplication.Models
{
    [Table("Orders")]
    public class Order
    {
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public OrderStatus Status { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public int DepartamentId { get; set; }
        public Department Department { get; set; }

        public byte[] Image { get; set; }
    }
}
