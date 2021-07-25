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
        Glass GetGlassById(int id);
        List<Glass> GetGlassesByOrderId(int id);
        double GlassArea(int id);
        double GlassPerimeter(int id);
        double GlassWeight(int id);
    }
}
