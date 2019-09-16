using Fakebook.BusinessLogicLayer.Abstract;
using Fakebook.DataAccessLayer.Concrete;
using Fakebook.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;

namespace Fakebook.BusinessLogicLayer.Concrete
{
    public class CoverImageBLL : IBusinessLogic<CoverImage>
    {
        private CoverImageDAL _coverImageDAL;

        public CoverImageBLL()
        {
            _coverImageDAL = new CoverImageDAL();
        }

        public void Add(CoverImage t)
        {
            _coverImageDAL.Add(t);
        }

        public void Delete(Guid id)
        {
            _coverImageDAL.Remove(Get(id));
        }

        public CoverImage Get(Guid id)
        {
            return _coverImageDAL.GetByID(id);
        }

        public List<CoverImage> GetAll()
        {
            return _coverImageDAL.GetActive();
        }

        public CoverImage GetCoverImageByUserID(Guid id)
        {
            return _coverImageDAL.GetByDefault(x => x.User.ID == id);
        }

        public void Update(CoverImage t)
        {
            _coverImageDAL.Update(t);
        }
    }
}
