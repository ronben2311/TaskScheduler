using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using WebApplication2.Controllers.JsonClasses;
using System.Text;

namespace WebApplication2.Controllers
{
    
    public class EmployeeController : ApiAbstractController
    { 
        [HttpPost]
        public async Task<IHttpActionResult> ValidateUser(validateUserJsonObj iObj)
        {
            try
            {
                var sha1 = System.Security.Cryptography.SHA1.Create();
                var inputBytes = System.Text.Encoding.ASCII.GetBytes(iObj.userPassword);
                var hash = sha1.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                for (var i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }

                var ret = await Models.Employee.ValidateUser(iObj.userName, sb.ToString(), DB);
                return Json(ret);
            }
            catch (Exception ex)
            {
                //write to ex log...
                return BadRequest();
            }
        }


    }
}
