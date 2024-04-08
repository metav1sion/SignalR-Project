using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class TestimonialManager : ITestimonialService
{
    private readonly ITestimonialDal _dal;

    public TestimonialManager(ITestimonialDal dal)
    {
        _dal = dal;
    }

    public void TAdd(Testimonial entity)
    {
        _dal.Add(entity);
    }

    public void TDelete(Testimonial entity)
    {
        _dal.Delete(entity);
    }

    public void TUpdate(Testimonial entity)
    {
        _dal.Update(entity);
    }

    public Testimonial TGetByID(int id)
    {
        return _dal.GetByID(id);
    }

    public List<Testimonial> TGetAll()
    {
        return _dal.GetAll();
    }
}