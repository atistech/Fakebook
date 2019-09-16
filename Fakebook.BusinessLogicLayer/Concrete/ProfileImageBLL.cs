using Fakebook.BusinessLogicLayer.Abstract;
using Fakebook.DataAccessLayer.Concrete;
using Fakebook.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakebook.BusinessLogicLayer.Concrete
{
    public class ProfileImageBLL : IBusinessLogic<ProfileImage>
    {
        private ProfileImageDAL _profileImageDAL;

        public ProfileImageBLL()
        {
            _profileImageDAL = new ProfileImageDAL();
        }

        public void Add(ProfileImage t)
        {
            _profileImageDAL.Add(t);
        }

        public void Delete(Guid id)
        {
            _profileImageDAL.Remove(id);
        }

        public ProfileImage Get(Guid id)
        {
            return _profileImageDAL.GetByID(id);
        }

        public List<ProfileImage> GetAll()
        {
            return _profileImageDAL.GetActive();
        }

        public ProfileImage GetProfileImageByUserID(Guid id)
        {
            return _profileImageDAL.GetByDefault(x => x.User.ID == id);
        }

        public void Update(ProfileImage p)
        {
            _profileImageDAL.Update(p);
        }
    }
}
