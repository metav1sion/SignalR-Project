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
    public class BookingManager : IBookingService
    {
        private IBookingDal _dal;

        public BookingManager(IBookingDal dal)
        {
            _dal = dal;
        }

        public void TAdd(Booking entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(Booking entity)
        {
            _dal.Delete(entity);
        }

        public void TUpdate(Booking entity)
        {
            _dal.Update(entity);
        }

        public Booking TGetByID(int id)
        {
            return _dal.GetByID(id);
        }

        public List<Booking> TGetAll()
        {
            return _dal.GetAll();
        }
    }
}
