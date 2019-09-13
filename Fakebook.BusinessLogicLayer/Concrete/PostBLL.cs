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
        private PostDAL postDAL;

        public PostBLL()
        {
            postDAL = new PostDAL();
        }

        public List<Post> getAllPostsByUserID(Guid id)
        {
            List<Post> ls = postDAL.GetDefault(x => x.User.ID == id);
            return ls;
        }
        
        public List<Post> GetAllPosts()
        {
            return postDAL.GetActive();
        }

        public Post GetById(Guid id)
        {
            return postDAL.GetByID(id);
        }

        public void Update(Post p)
        {
            postDAL.Update(p);
        }

        public void DeletePost(Guid id)
        {
            postDAL.Remove(postDAL.GetByID(id));
        }
    }
}
