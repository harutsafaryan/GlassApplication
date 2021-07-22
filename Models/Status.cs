using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GlassApplication.Models
{
    public enum OrderStatus
    {
        Draft = 1,
        Accepted,
        InProcess,
        Canceled,
        Finished
    }

    [Table("Statuses")]
    public class Status
    {
        public int Id { get; set; }
        public OrderStatus Name { get; set; }
    }
}
