using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Controllers.JsonClasses
{
    //represnt a given js object, in order to avoid runtime Jobject parsing...  iObject["userPassword"].ToObject<string>();
    public class validateUserJsonObj
    {
        public string userName  { get; set; }
        public string userPassword { get; set; }
    }
}