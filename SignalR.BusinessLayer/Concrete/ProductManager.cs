using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class ProductManager :IProductService
    {
        private readonly IProductDal _dal;

        public ProductManager(IProductDal dal)
        {
            _dal = dal;
        }

        public void TAdd(Product entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _dal.Delete(entity);
        }

        public void TUpdate(Product entity)
        {
            _dal.Update(entity);
        }

        public Product TGetByID(int id)
        {
            return _dal.GetByID(id);
        }

        public List<Product> TGetAll()
        {
            return _dal.GetAll();
        }

        public List<Product> TGetProductsWithCategories()
        {
            return _dal.GetProductsWithCategories();
        }
    }
}
