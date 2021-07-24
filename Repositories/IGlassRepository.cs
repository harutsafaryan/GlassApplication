using GlassApplication.Models;
using GlassApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassApplication.Repositories
{
    public interface IGlassRepository : IRepository<Glass>
    {
        Task<Glass> GetGlassByIdAsync(int id);
        Task<IList<Glass>> GetGlassesByOrderIdAsync(int id);
        Task<double> GlassArea(int id);
        Task<double> GlassPerimeter(int id);
        Task<double> GlassWeight(int id);
    }
}
