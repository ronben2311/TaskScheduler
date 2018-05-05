using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Data.Entity;
using System.Web.Http;
using WebApplication2.Controllers.JsonClasses;

namespace WebApplication2.Controllers
{
    public class ProjectController : ApiAbstractController
    {
        [HttpGet]
        public async Task<IHttpActionResult> GetCustomersProjects(int ciCustomerId)
        {
            try
            {
                var ret = await Models.Project.GetCustomersProjects(ciCustomerId, DB);
                return Json(ret);
            }
            catch (Exception ex)
            {
                //write ex to log...
                return BadRequest();
            }
        }
    }
}