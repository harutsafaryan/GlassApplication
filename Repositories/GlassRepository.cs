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
    public class GlassRepository : Repository<Glass>, IGlassRepository
    {
        public GlassRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Glass GetGlassById(int id)
        {
            return ReadAll().FirstOrDefault(x => x.Id==id);
        }

        public List<Glass> GetGlassesByOrderId(int id)
        {
            return ReadAll().Where(x => x.OrderId == id).ToList();
        }

        public double GlassArea(int id)
        {
            Glass trackedEntity = GetGlassById(id);
            double result = trackedEntity.Height * trackedEntity.Width / 1_000_000;
            return result;
        }

        public double GlassPerimeter(int id)
        {
            Glass trackedEntity = GetGlassById(id);
            double result = (trackedEntity.Height + trackedEntity.Width) * 0.002;
            return result;
        }

        public double GlassWeight(int id)
        {
            Glass trackedEntity = GetGlassById(id);
            double result = trackedEntity.Height * trackedEntity.Width * trackedEntity.Thickness * 2.5;
            result = result / 1_000_000;
            return result;
        }
    }
}
