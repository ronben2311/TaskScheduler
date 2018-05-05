using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
namespace WebApplication2.Models
{
    public partial class Employee
    {
        public async static Task<object> GetAllEmployee(DbModel iDb)
        {
            var returnObj = await iDb.Employee.Select(x => x.userName).ToListAsync();
            return returnObj;
        }

        public async static Task<object> ValidateUser (string iUserName , string iUserPassword , DbModel iDb)
        {
            var returnObj = await iDb.Employee.Where(x => x.userName == iUserName && x.userPassword == iUserPassword).Select(x => new { userId = x.id , userName = x.firstName + " " +x.lastName  }).FirstOrDefaultAsync();

            return returnObj;
        }
    }
}