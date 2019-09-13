using Fakebook.DataAccessLayer.Abstract;
using Fakebook.DataAccessLayer.Concrete;
using Fakebook.EntitiesLayer.Entities;
using LightInject;

namespace Fakebook.BusinessLogicLayer.LightInject
{
    public class ContainerConfig
    {
        public static ServiceContainer getServiceContainer()
        {
            var container = new ServiceContainer();
            container.Register<BaseDataAccess<User>, UserDAL>();
            container.Register<BaseDataAccess<Post>, PostDAL>();
            container.Register<BaseDataAccess<Image>, ImageDAL>();
            container.Register<BaseDataAccess<ProfileImage>, ProfileImageDAL>();
            return container;
        }
    }
}
