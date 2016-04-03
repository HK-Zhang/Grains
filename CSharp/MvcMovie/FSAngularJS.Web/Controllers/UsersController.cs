using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSAngularJS.Web.Controllers
{
    public class UsersController :BaseApiController
    {
        public bool Get(string userName)
        {
            //return true;
            return TheRepository.UserNameExists(userName);
        }
    }
}