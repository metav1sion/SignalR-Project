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
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _dal;

        public FeatureManager(IFeatureDal dal)
        {
            _dal = dal;
        }

        public void TAdd(Feature entity)
        {
            _dal.Add(entity);
        }

        public void TDelete(Feature entity)
        {
            _dal.Delete(entity);
        }

        public void TUpdate(Feature entity)
        {
            _dal.Update(entity);
        }

        public Feature TGetByID(int id)
        {
            return _dal.GetByID(id);
        }

        public List<Feature> TGetAll()
        {
            return _dal.GetAll();
        }
    }
}
