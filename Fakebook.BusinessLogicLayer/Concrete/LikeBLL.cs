using Fakebook.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakebook.BusinessLogicLayer.Concrete
{
    public class LikeBLL
    {
        private LikeDAL _likeDAL;

        public LikeBLL() => 
            _likeDAL = new LikeDAL();

        public int LikesCountByPostID(Guid id) => 
            _likeDAL.GetDefault(x => x.PostID == id).Count;

        public int LikesCountCommentID(Guid id) =>
            _likeDAL.GetDefault(x => x.CommentID == id).Count;

        public void AddLikeForPost(Guid id) =>
            _likeDAL.Add(
                _likeDAL.GetByDefault(x => x.PostID == id));

        public void AddLikeForComment(Guid id) =>
            _likeDAL.Add(
                _likeDAL.GetByDefault(x => x.CommentID == id));

        public void RemoveLikeForPost(Guid id) =>
            _likeDAL.Remove(
                _likeDAL.GetByDefault(x => x.PostID == id));

        public void RemoveLikeForComment(Guid id) =>
            _likeDAL.Remove(
                _likeDAL.GetByDefault(x => x.CommentID == id));
    }
}
