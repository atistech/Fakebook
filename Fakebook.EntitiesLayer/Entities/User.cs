using Fakebook.CoreLayer.EntitiesLayer;
using System.Collections.Generic;

namespace Fakebook.EntitiesLayer.Entities
{
    public enum Role
    {
        None = 0,
        Member = 1,
        Admin = 3
    }
    public class User : CoreEntity
    {
        public User()
        {
            Images = new HashSet<Image>();
            Posts = new HashSet<Post>();
            Users = new HashSet<User>();
        }
        public Role Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
