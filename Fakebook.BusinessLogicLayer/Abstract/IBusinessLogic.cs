using Fakebook.CoreLayer.EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakebook.BusinessLogicLayer.Abstract
{
    public interface IBusinessLogic<T> where  T : CoreEntity
    {
        List<T> GetAll();
        T Get(Guid id);
        void Add(T t);
        void Update(T t);
        void Delete(Guid id);
    }
}
