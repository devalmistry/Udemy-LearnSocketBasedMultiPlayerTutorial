using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using GameServer01.DAO;
using GameServer01.Model;
using GameServer01.Servers;

namespace GameServer01.Conroller
{
    class UserController : BaseController
    {

        private UserDAO userDAO = new UserDAO();

        public UserController()
        {
            requestCode = RequestCode.User;
        }

        public string Login(string data, Client client, Server server)
        {
            string[] strs = data.Split(',');
           User user = userDAO.VerifyUser(client.MySqlConn, strs[0], strs[1]);

            if (user==null)
            {
                return ((int)ReturnCode.fail).ToString();
            }
            else
            {
                return ((int)ReturnCode.success).ToString();
            }
        }
    }
}
