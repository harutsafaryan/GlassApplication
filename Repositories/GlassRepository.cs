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

        public Task<Glass> GetGlassByIdAsync(int id)
        {
            return GetAll().FirstOrDefaultAsync(x => x.Id==id);
        }

        public async Task<IList<Glass>> GetGlassesByOrderIdAsync(int id)
        {
            return await GetAll().Where(x => x.OrderId == id).ToListAsync();
        }

        public async Task<double> GlassArea(int id)
        {
            Glass trackedEntity = await GetGlassByIdAsync(id);
            double result = trackedEntity.Height * trackedEntity.Width / 1_000_000;
            return result;
        }

        public async Task<double> GlassPerimeter(int id)
        {
            Glass trackedEntity = await GetGlassByIdAsync(id);
            double result = (trackedEntity.Height + trackedEntity.Width) * 0.002;
            return result;
        }

        public async Task<double> GlassWeight(int id)
        {
            Glass trackedEntity = await GetGlassByIdAsync(id);
            double result = trackedEntity.Height * trackedEntity.Width * trackedEntity.Thickness * 2.5;
            result = result / 1_000_000;
            return result;
        }
    }
}
