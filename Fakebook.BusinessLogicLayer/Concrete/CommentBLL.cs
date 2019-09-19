using System;
using System.Collections.Generic;
using Fakebook.BusinessLogicLayer.Abstract;
using Fakebook.DataAccessLayer.Concrete;
using Fakebook.EntitiesLayer.Entities;

namespace Fakebook.BusinessLogicLayer.Concrete
{
    public class CommentBLL : IBusinessLogic<Comment>
    {
        private CommentDAL _commentDAL;

        public CommentBLL()
        {
            _commentDAL = new CommentDAL();
        }

        public List<Comment> GetCommentsByPostID(Guid id)
        {
            if(_commentDAL.GetDefault(x => x.PostID == id)!=null)
                return _commentDAL.GetDefault(x => x.PostID == id);
            else
                return null;
        }

        public void Add(Comment t)
        {
            _commentDAL.Add(t);
        }

        public void Delete(Guid id)
        {
            _commentDAL.Remove(Get(id));
        }

        public Comment Get(Guid id)
        {
            return _commentDAL.GetByID(id);
        }

        public List<Comment> GetAll()
        {
            return _commentDAL.GetActive();
        }

        public void Update(Comment t)
        {
            _commentDAL.Update(t);
        }
    }
}
