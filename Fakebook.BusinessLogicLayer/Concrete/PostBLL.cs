using Fakebook.BusinessLogicLayer.LightInject;
using Fakebook.DataAccessLayer.Abstract;
using Fakebook.DataAccessLayer.Concrete;
using Fakebook.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;

namespace Fakebook.BusinessLogicLayer.Concrete
{
    public class PostBLL
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

        public List<Post> GetAllPosts()
        {
            return _postDAL.GetActive();
        }

        public Post GetById(Guid id)
        {
            return _postDAL.GetByID(id);
        }

        public void Update(Post p)
        {
            _postDAL.Update(p);
        }

        public void DeletePost(Guid id)
        {
            _postDAL.Remove(_postDAL.GetByID(id));
        }
    }
}
