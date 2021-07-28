using GlassApplication.Data;
using GlassApplication.Models;
using GlassApplication.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassApplication.Repositories
{
    public class OrderRepository : Repository<Order>,  IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
