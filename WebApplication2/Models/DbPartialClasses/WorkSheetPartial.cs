using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Dynamic;
namespace WebApplication2.Models
{
    public partial class WorkSheet
    {
        public async static Task<object> PresentWorkSheetByProjectId(int iProjectId, int iEmployeeId, int iPageSize, int iPageNumber, string iTaskPartialName, string iChosenColumn, string iOrderBy, DbModel iDb)
        {
            var retWorkSheetList = await iDb.WorkSheet.Where(x => x.Task.projectId == iProjectId && x.employeeId == iEmployeeId).
                            Select(x => new
                            {
                                id = x.Id,
                                taskName = x.Task.name,
                                taskId = x.Task.id,
                                projectName = x.Task.Project.name,
                                projectId = x.Task.projectId,
                                customerName = x.Task.Project.Customer.name,
                                dateYear = x.sheetDate.Value.Year,
                                dateMonth = x.sheetDate.Value.Month,
                                dateDay = x.sheetDate.Value.Day,
                                startHour = x.startingHour,
                                endHour = x.endingHour,
                                comment = x.comment
                            }).OrderBy(iChosenColumn + iOrderBy).ToListAsync(); //.Skip(iPageSize * iPageNumber).Take(iPageSize).ToListAsync();

            var totalRes = iDb.WorkSheet.Where(x => x.Task.projectId == iProjectId).Count();

            return new { retWorkSheetList = retWorkSheetList, totalCount = totalRes };
        }

        public async static Task<bool> EditWorkSheet(int iSHeetId, DateTime iDate, TimeSpan iStartHour, TimeSpan iEndHour, string iComment, int iTaskId, DbModel iDb)
        {
            var sheetToEdit = await iDb.WorkSheet.Where(x => x.Id == iSHeetId).FirstOrDefaultAsync();

            sheetToEdit.sheetDate = iDate;
            sheetToEdit.startingHour = iStartHour;
            sheetToEdit.endingHour = iEndHour;
            sheetToEdit.comment = iComment;
            sheetToEdit.taskId = iTaskId;

            try
            {
                await iDb.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async static Task<bool> DeleteSheet(int iSHeetId, DbModel iDb)
        {
            var sheetToEdit = await iDb.WorkSheet.Where(x => x.Id == iSHeetId).FirstOrDefaultAsync();

            try
            {
                iDb.WorkSheet.Remove(sheetToEdit);
                await iDb.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async static Task<bool> AddWorkSheet(int iEmployeeId, int iTaskId, DateTime iDate, TimeSpan iStartHour, TimeSpan iEndHour, string iComment, DbModel iDb)
        {
            var sheetToAdd = new Models.WorkSheet
            {
                taskId = iTaskId,
                employeeId = iEmployeeId,
                sheetDate = iDate,
                startingHour = iStartHour,
                endingHour = iEndHour,
                comment = iComment
            };

            try
            {
                iDb.WorkSheet.Add(sheetToAdd);
                await iDb.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}