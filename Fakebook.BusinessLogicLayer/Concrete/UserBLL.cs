using Fakebook.BusinessLogicLayer.Abstract;
using Fakebook.DataAccessLayer.Concrete;
using Fakebook.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;

namespace Fakebook.BusinessLogicLayer.Concrete
{
    public class UserBLL : IBusinessLogic<User>
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

        public List<User> GetAll()
        {
            return _userDAL.GetActive();
        }

        public User Get(Guid id)
        {
            return _userDAL.GetByID(id);
        }

        public void Add(User t)
        {
            _userDAL.Add(t);
        }

        public void Update(User t)
        {
            _userDAL.Update(t);
        }

        public void Delete(Guid id)
        {
            _userDAL.Remove(id);
        }
    }
}
