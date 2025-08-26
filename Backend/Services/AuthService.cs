using System.Collections.Generic;
using System.Linq;
using Backend.Models;

namespace Backend.Services
{
    public class AuthService
    {
        private readonly List<User> _users = new()
        {
            new User { Username = "admin", Password = "admin123", Role = Roles.Admin },
            new User { Username = "editor", Password = "editor123", Role = Roles.Editor },
            new User { Username = "viewer", Password = "viewer123", Role = Roles.Viewer }
        };

        public User ValidateUser(string username, string password)
        {
            return _users.FirstOrDefault(u =>
                u.Username == username && u.Password == password);
        }
    }
}
