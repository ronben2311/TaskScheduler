using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Dynamic;

namespace WebApplication2.Models
{
    public partial class Task
    {
        public async static Task<object> GetProjectTasks(int iProjectId, DbModel iDb)
        {
            var retObj = await iDb.Task.Where(x => x.projectId == iProjectId).
                Select(x => new { id = x.id, name = x.name }).ToListAsync();
            return retObj;
        }

    }
}