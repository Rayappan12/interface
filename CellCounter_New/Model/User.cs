using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellCounter_New.Model
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class SessionTimeOut
    {
        public string status { get; set; }
    }

    public class Users
    {
        public List<User> UsersList { get; set; }
    }
    public class Logout
    {
        public string message { get; set; }
    }
}
