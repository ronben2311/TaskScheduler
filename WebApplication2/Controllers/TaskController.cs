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
    public class TaskController : ApiAbstractController
    {
        [HttpGet]
        public async Task<IHttpActionResult> GetTasksByProjectId(int ciProjectId)
        {
            try
            {
                var ret = await Models.Task.GetProjectTasks(ciProjectId, DB);
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