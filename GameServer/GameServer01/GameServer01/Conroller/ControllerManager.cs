using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Reflection;
using GameServer01.Servers;

namespace GameServer01.Conroller
{
    class ControllerManager
    {
        private Dictionary<RequestCode, BaseController> controllerDict = new Dictionary<RequestCode, BaseController>();

        private Server server;

        public ControllerManager(Server server)
        {
            this.server = server;
        }

        private void OnInIt()
        {
            DefaultController defaultController = new DefaultController();
            controllerDict.Add(defaultController.RequestCode, new DefaultController());
        }

        public void HandleRequest(RequestCode requestCode, ActionCode actionCode, string data, Client client)
        {
            BaseController controller;
            bool isGet = controllerDict.TryGetValue(requestCode, out controller);

            if (!isGet)
            {
                Console.WriteLine("Can't Found controller for: " + requestCode);

            }

            string methodName = Enum.GetName(typeof(ActionCode), actionCode);
            MethodInfo mi = controller.GetType().GetMethod(methodName);

            if (mi == null)
            {
                Console.WriteLine("There is no corresponding Methis: " + methodName);
                return;
            }
            object[] parameters = new object[] { data, client, server };
            object o = mi.Invoke(controller, parameters);

            if (o == null)
            {
                return;
            }
            server.SendResponse(client, actionCode,o as string);


        }
    }
}