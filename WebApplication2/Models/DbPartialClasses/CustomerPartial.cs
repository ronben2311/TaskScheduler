using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebApplication2.Models
{
    public partial class Customer
    {
        public async static Task<object> GetAllCustomers(DbModel iDb)
        {
            var retObj = await iDb.Customer.Select(x => new { id = x.id, name = x.name , projCount = x.Project.Count }).ToListAsync();
            return retObj;
        }
    }
}