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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _dal;

        public ContactManager(IContactDal dal)
        {
            _dal = dal;
        }

        public void TAdd(Contact entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(Contact entity)
        {
            _dal.Delete(entity);
        }

        public void TUpdate(Contact entity)
        {
            _dal.Update(entity);
        }

        public Contact TGetByID(int id)
        {
            return _dal.GetByID(id);
        }

        public List<Contact> TGetAll()
        {
            return _dal.GetAll();
        }
    }
}
