using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer01.Model
{
    class User
    {
        private int Id { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }

        public User(int _id, string _username, string _password)
        {
            this.Id = Id;
            this.Username = _username;
            this.Password = _password;
        }
    }
}
