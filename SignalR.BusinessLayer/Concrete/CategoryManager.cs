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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _dal;

        public CategoryManager(ICategoryDal dal)
        {
            _dal = dal;
        }

        public void TAdd(Category entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(Category entity)
        {
            _dal.Delete(entity);
        }

        public void TUpdate(Category entity)
        {
            _dal.Update(entity);
        }

        public Category TGetByID(int id)
        {
            return _dal.GetByID(id);
        }

        public List<Category> TGetAll()
        {
            return _dal.GetAll();
        }
    }
}
