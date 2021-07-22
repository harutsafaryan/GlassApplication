using GlassApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassApplication.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Orders.Any())
            {
                return; // DB has been seeded
            }

            var departmets = new Department[]
                {
                    new Department() { Name="Alyumin"},
                    new Department() { Name="Fasad"},
                    new Department() { Name="Sale"},
                    new Department() { Name="STK"},
                };

            foreach (Department item in departmets)
            {
                context.Departments.Add(item);
            }
            context.SaveChanges();

            var orders = new Order[]
                {
                    new Order() { OrderNumber=14, Department=departmets[0], StartDate=DateTime.Now, EndDate=DateTime.Now, Status=OrderStatus.Accepted},
                    new Order() { OrderNumber=45, Department=departmets[1], StartDate=DateTime.Now, EndDate=DateTime.Now, Status=OrderStatus.Draft},
                    new Order() { OrderNumber=12, Department=departmets[1], StartDate=DateTime.Now, EndDate=DateTime.Now, Status=OrderStatus.Finished},
                    new Order() { OrderNumber=89, Department=departmets[2], StartDate=DateTime.Now, EndDate=DateTime.Now, Status=OrderStatus.InProcess},
                    new Order() { OrderNumber=652, Department=departmets[2], StartDate=DateTime.Now, EndDate=DateTime.Now, Status=OrderStatus.InProcess},
                    new Order() { OrderNumber=41, Department=departmets[3], StartDate=DateTime.Now, EndDate=DateTime.Now, Status=OrderStatus.Accepted},
                    new Order() { OrderNumber=22, Department=departmets[3], StartDate=DateTime.Now, EndDate=DateTime.Now, Status=OrderStatus.Canceled},
                    new Order() { OrderNumber=3, Department=departmets[3], StartDate=DateTime.Now, EndDate=DateTime.Now, Status=OrderStatus.Finished},
                    new Order() { OrderNumber=145, Department=departmets[3], StartDate=DateTime.Now, EndDate=DateTime.Now, Status=OrderStatus.InProcess},
                };

            foreach (Order item in orders)
            {
                context.Orders.Add(item);
            }
            context.SaveChanges();

        }

    }
}
