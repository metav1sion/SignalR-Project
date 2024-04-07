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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _dal;

        public AboutManager(IAboutDal dal)
        {
            _dal = dal;
        }

        public void TAdd(About entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(About entity)
        {
            _dal.Delete(entity);
        }

        public void TUpdate(About entity)
        {
            _dal.Update(entity);
        }

        public About TGetByID(int id)
        {
            return _dal.GetByID(id);
        }

        public List<About> TGetAll()
        {
            return _dal.GetAll();
        }
    }
}
