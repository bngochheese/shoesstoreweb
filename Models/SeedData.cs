using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoesStoreWebsite.Data;
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;

namespace ShoesStoreWebsite.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationDbContext>>()))
        {
            // Look for any movies.
            if (context.Shoes.Any())
            {
                return;   // DB has been seeded
            }
            context.Shoes.AddRange(
                new Shoes
                {

                    Brand = "NIKE",
                    Category = "Nike Air Force 1",
                    Name = "Nike Air Force 1 Shadow All White",
                    Gender = "Unisex",
                    Material = "",
                    Sole = "",
                    Color = "White",
                    Size = "VN 37",
                    Storagen_Instructions = "A",
                    Price = 8.000000M,
                    URLImage = "https://static.nike.com/a/images/t_PDP_864_v1/f_auto,b_rgb:f5f5f5/f094af40-f82f-4fb9-a246-e031bf6fc411/air-force-1-07-shoes-NMmm1B.png"

                },
                new Shoes
                {

                    Brand = "NIKE",
                    Category = "Nike Air Max",
                    Name = "Nike Air Max 270",
                    Gender = "Unisex",
                    Material = "",
                    Sole = "",
                    Color = "White/Deep Royal Blue/Hyper Jade",
                    Size = "VN 37",
                    Storagen_Instructions = "A",
                    Price = 8.000000M,
                    URLImage = "https://static.nike.com/a/images/t_PDP_864_v1/f_auto,b_rgb:f5f5f5/92acefac-fa58-409f-8893-61093b2e9255/air-max-270-shoes-vjpNZc.png"
                },
                new Shoes
                {

                    Brand = "NIKE",
                    Category = "Nike Air Jordan",
                    Name = "Air Jordan 1 Mid",
                    Gender = "Unisex",
                    Material = "",
                    Sole = "",
                    Color = " White/Black/Green Glow",
                    Size = "VN 37",
                    Storagen_Instructions = "A",
                    Price = 8.000000M,
                    URLImage = "https://static.nike.com/a/images/t_PDP_864_v1/f_auto,b_rgb:f5f5f5,u_126ab356-44d8-4a06-89b4-fcdcc8df0245,c_scale,fl_relative,w_1.0,h_1.0,fl_layer_apply/aff63355-b2e9-47fb-adae-4b60ba1f602e/air-jordan-1-mid-shoes-SQf7DM.png"

                },
                new Shoes
                {

                    Brand = "NIKE",
                    Category = "Nike Running",
                    Name = "Nike Invincible 3",
                    Gender = "Unisex",
                    Material = "",
                    Sole = "",
                    Color = "White/Dusty Cactus/Bright Crimson/Black",
                    Size = "VN 37",
                    Storagen_Instructions = "A",
                    Price = 8.000000M,
                    URLImage = "https://static.nike.com/a/images/t_PDP_864_v1/f_auto,b_rgb:f5f5f5/40e9a096-e6cc-4c39-aec8-46a330f80681/invincible-3-road-running-shoes-jkhK7v.png"

                }



            );
            context.SaveChanges();
        }
    }
}