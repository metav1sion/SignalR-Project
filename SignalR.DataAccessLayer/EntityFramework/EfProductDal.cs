using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfProductDal : GenericRepository<Product>,IProductDal
{
    private readonly SignalRContext _context;
    public EfProductDal(SignalRContext context) : base(context)
    {
        _context = context;
    }

    public List<Product> GetProductsWithCategories()
    {
        //var context = new SignalRContext();
        //SignalRContext context = new SignalRContext();
        var values = _context.Products.Include(x => x.Category).ToList();
        return values;
    }
}