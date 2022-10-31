using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace GameServer01.Conroller
{
   abstract class BaseController
    {
        protected RequestCode requestCode = RequestCode.None;
        public RequestCode RequestCode {
            get {
                return requestCode;
            }
        }
    }
}