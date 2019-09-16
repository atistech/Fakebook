using Fakebook.BusinessLogicLayer.Abstract;
using Fakebook.CoreLayer.EntitiesLayer.Enum;
using Fakebook.DataAccessLayer.Concrete;
using Fakebook.EntitiesLayer.Entities;
using System;
using System.Collections.Generic;

namespace Fakebook.BusinessLogicLayer.Concrete
{
    public class LikeBLL : IBusinessLogic<Like>
    {
        private LikeDAL _likeDAL;

        public LikeBLL()
        {
            _likeDAL = new LikeDAL();
        }

        public int LikesCount(Guid id)
        {
            return _likeDAL.GetDefault(x => x.ItemID == id
&& x.Status != Status.Deleted).Count;
        }

        public void Add(Guid OwnerId, Guid ItemId)
        {
            Like like = new Like();
            like.ID = Guid.NewGuid();
            like.OwnerID = OwnerId;
            like.ItemID = ItemId;
            _likeDAL.Add(like);
        }

        public void Remove(Guid ItemId)
        {
            _likeDAL.Remove(_likeDAL.GetByDefault(x => x.ItemID == ItemId));
        }

        public bool UserLikeStatus(Guid UserId, Guid ItemId)
        {
            if (_likeDAL.GetByDefault(x => x.ItemID == ItemId
                 && x.OwnerID == UserId)!=null)
                return true;
            else
                return false;
        }

        public List<Like> GetAll()
        {
            return _likeDAL.GetActive();
        }

        public Like Get(Guid id)
        {
            return _likeDAL.GetByID(id);
        }

        public void Add(Like t)
        {
            _likeDAL.Add(t);
        }

        public void Update(Like t)
        {
            _likeDAL.Update(t);
        }

        public void Delete(Guid id)
        {
            _likeDAL.Remove(Get(id));
        }
    }
}
