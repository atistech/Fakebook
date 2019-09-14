using Fakebook.DataAccessLayer.Concrete;
using Fakebook.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakebook.BusinessLogicLayer.Concrete
{
    public class CoverImageBLL
    {
        private CoverImageDAL _coverImageDAL;

        public CoverImageBLL() =>
            _coverImageDAL = new CoverImageDAL();

        public CoverImage GetCoverImageByUserID(Guid id) =>
            _coverImageDAL.GetByDefault(x => x.User.ID == id);
    }
}
