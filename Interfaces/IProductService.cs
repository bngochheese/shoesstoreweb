using ShoesStoreWebsite.Models;

namespace ShoesStoreWebsite.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Shoes> GetShoes();
        Shoes GetShoe(int id);
    }
}
