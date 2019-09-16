using Fakebook.BusinessLogicLayer.Abstract;
using Fakebook.DataAccessLayer.Concrete;
using Fakebook.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;

namespace Fakebook.BusinessLogicLayer.Concrete
{
    public class ImageBLL : IBusinessLogic<Image>
    {
        private ImageDAL _imageDAL;

        public ImageBLL()
        {
            _imageDAL = new ImageDAL();
        }

        public void Add(Image t)
        {
            _imageDAL.Add(t);
        }

        public void Delete(Guid id)
        {
            _imageDAL.Remove(Get(id));
        }

        public Image Get(Guid id)
        {
            return _imageDAL.GetByID(id);
        }

        public List<Image> GetAll()
        {
            return _imageDAL.GetActive();
        }

        public void Update(Image t)
        {
            _imageDAL.Update(t);
        }
    }
}
