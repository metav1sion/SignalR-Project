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
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _dal;

        public DiscountManager(IDiscountDal dal)
        {
            _dal = dal;
        }

        public void TAdd(Discount entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(Discount entity)
        {
            _dal.Delete(entity);
        }

        public void TUpdate(Discount entity)
        {
            _dal.Update(entity);
        }

        public Discount TGetByID(int id)
        {
            return _dal.GetByID(id);
        }

        public List<Discount> TGetAll()
        {
            return _dal.GetAll();
        }
    }
}
