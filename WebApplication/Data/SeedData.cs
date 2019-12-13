using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Data
{
    public static class SeedData
    {
         public static void Initialize(ItemsContext context)
        { 
            if (!context.Items.Any())
            {
                context.Items.AddRange(
                    new Item
                    {
                        Name = "Squeaky Bone",
                        Gender = "Male",
                        Color = "red",
                        Size = 0,
                    },
                    new Item
                    {
                        Name = "Knotted Rope",
                        Gender = "Female",
                        Color = "green",
                        Size = 0,
                    }
                );
                context.SaveChanges();
            }
        }
    
    }
}
