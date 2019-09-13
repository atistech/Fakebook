using Fakebook.DataAccessLayer.Concrete;
using Fakebook.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakebook.BusinessLogicLayer.Concrete
{
    public class ProfileImageBLL
    {
        private ProfileImageDAL _profileImageDAL;

        public ProfileImageBLL() =>
            _profileImageDAL = new ProfileImageDAL();

        public ProfileImage GetProfileImageByUserID(Guid id) =>
            _profileImageDAL.GetByDefault(x => x.User.ID == id);

        public void Update(ProfileImage p) =>
            _profileImageDAL.Update(p);
    }
}
