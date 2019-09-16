using Fakebook.BusinessLogicLayer.Abstract;
using Fakebook.DataAccessLayer.Concrete;
using Fakebook.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;

namespace Fakebook.BusinessLogicLayer.Concrete
{
    public class PostBLL : IBusinessLogic<Post>
    {
        private PostDAL _postDAL;
        private UserDAL _userDAL;

        public PostBLL()
        {
            _postDAL = new PostDAL();
            _userDAL = new UserDAL();
        }

        public List<Post> getAllPostsByUserID(Guid id)
        {
            List<Post> ls = _postDAL.GetDefault(x => x.User.ID == id);
            foreach(User u in _userDAL.GetByID(id).Users)
            {
                ls.AddRange(_postDAL.GetDefault(x => x.User.ID == u.ID));
            }
            return ls;
        }

        public List<Post> getProfilePostsByUserID(Guid id)
        {
            return _postDAL.GetDefault(x => x.User.ID == id);
        }

        public void Update(Post p)
        {
            _postDAL.Update(p);
        }

        public List<Post> GetAll()
        {
            return _postDAL.GetActive();
        }

        public Post Get(Guid id)
        {
            return _postDAL.GetByID(id);
        }

        public void Add(Post t)
        {
            _postDAL.Add(t);
        }

        public void Delete(Guid id)
        {
            _postDAL.Remove(Get(id));
        }
    }
}
