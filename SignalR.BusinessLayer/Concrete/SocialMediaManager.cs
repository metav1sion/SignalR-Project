using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class SocialMediaManager : ISocialMediaService
{
    private readonly ISocialMediaDal _dal;

    public SocialMediaManager(ISocialMediaDal dal)
    {
        _dal = dal;
    }

    public void TAdd(SocialMedia entity)
    {
        _dal.Add(entity);
    }

    public void TDelete(SocialMedia entity)
    {
        _dal.Delete(entity);
    }

    public void TUpdate(SocialMedia entity)
    {
        _dal.Update(entity);
    }

    public SocialMedia TGetByID(int id)
    {
        return _dal.GetByID(id);
    }

    public List<SocialMedia> TGetAll()
    {
        return _dal.GetAll();
    }
}