using Fakebook.DataAccessLayer.Concrete;
using Fakebook.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;

namespace Fakebook.BusinessLogicLayer.Concrete
{
    public class UserBLL
    {
        private UserDAL _userDAL;

        public UserBLL()
        {
            _userDAL = new UserDAL();
        }
        
        public User GetByEmailandPassword(string email, string password)
        {
            return _userDAL.GetByDefault(x => (x.Email == email)&&(x.Password == password));
        }

        public User GetByEmail(string email)
        {
            return _userDAL.GetByDefault(x => x.Email == email);
        }

        public User GetByID(Guid id)
        {
            return _userDAL.GetByID(id);
        }

        public List<User> GetAllUsers()
        {
            return _userDAL.GetActive();
        }

        public void DeleteUser(Guid id)
        {
            _userDAL.Remove(id);
        }

        public void UpdateUser(User u)
        {
            _userDAL.Update(u);
        }
    }
}
