using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfCategoryDal : GenericRepository<Category>,ICategoryDal
{
    public EfCategoryDal(SignalRContext context) : base(context)
    {
    }
}