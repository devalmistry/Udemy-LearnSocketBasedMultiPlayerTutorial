using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Reflection;

namespace GameServer01.Conroller
{
    class ControllerManager
    {
        private Dictionary<RequestCode, BaseController> controllerDict = new Dictionary<RequestCode, BaseController>();

        public ControllerManager()
        {

        }

        private void OnInIt()
        {
            DefaultController defaultController = new DefaultController();
            controllerDict.Add(defaultController.RequestCode, new DefaultController());
        }

        private void HandleRequest(RequestCode requestCode, ActionCode actionCode, string data)
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

            object[] parameters = new object[] { data };
            object o = mi.Invoke(controller, parameters);
        }
    }
}