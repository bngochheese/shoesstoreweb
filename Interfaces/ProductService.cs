using ShoesStoreWebsite.Models;
using ShoesStoreWebsite.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShoesStoreWebsite.Data;

namespace ShoesStoreWebsite.Interfaces
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Shoes GetShoe(int id)
        {
            return _context.Shoes.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Shoes> GetShoes()
        {
            return _context.Shoes.ToList();
        }
    }
}
