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
    public class WorkSheetController : ApiAbstractController
    {
        [HttpPost]
        public async Task<IHttpActionResult> WorkSheetByProjectId(searchWorkSheetJson iObj)
        {
            try
            {
                var ret = await Models.WorkSheet.PresentWorkSheetByProjectId(iObj.projectId, iObj.employeeId,iObj.pageSize, iObj.pageNumber, iObj.taskPartialName, iObj.chosenColumn, iObj.orderBy, DB);
                return Json(ret);
            }
            catch (Exception exc)
            {
                //write exc to log...
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> SaveSheet(SaveSheetJson iObj)
        {
            using (var transaction = DB.Database.BeginTransaction())
            {
                try
                {
                    var ret = await Models.WorkSheet.EditWorkSheet(iObj.sheetId, iObj.date, iObj.newStartHour.TimeOfDay, iObj.newEndHour.TimeOfDay, iObj.newComment, iObj.taskId, DB);
                    transaction.Commit();
                    return Json(ret);
                }
                catch (Exception exc)
                {
                    transaction.Rollback();
                    //write exc to log...
                    return BadRequest();
                }
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> DeleteSheet(int ciSheetId)
        {
            using (var transaction = DB.Database.BeginTransaction())
            {
                try
                {
                    var ret = await Models.WorkSheet.DeleteSheet(ciSheetId , DB);
                    transaction.Commit();
                    return Json(ret);
                }
                catch (Exception exc)
                {
                    transaction.Rollback();
                    //write exc to log...
                    return BadRequest();
                }
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddWorkSheet(SaveSheetJson iObj)
        {
            using (var transaction = DB.Database.BeginTransaction())
            {
                try
                {
                    var ret = await Models.WorkSheet.AddWorkSheet(iObj.employeeId, iObj.taskId, iObj.date,
                                                     iObj.newStartHour.TimeOfDay, iObj.newEndHour.TimeOfDay, iObj.newComment, DB);
                    transaction.Commit();
                    return Json(ret);
                }
                catch (Exception exc)
                {
                    transaction.Rollback();
                    //write exc to log...
                    return BadRequest();
                }
            }
        }


    }
}