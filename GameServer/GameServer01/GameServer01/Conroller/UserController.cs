using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using GameServer01.Servers;

namespace GameServer01.Conroller
{
    class UserController:BaseController
    {
        public UserController() {
            requestCode = RequestCode.User;
        }

        public void Login(string data, Client client, Server server) {
            
        }
    }
}
