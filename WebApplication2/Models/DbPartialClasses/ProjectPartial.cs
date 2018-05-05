using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebApplication2.Models
{
    public partial class Project
    {
        public async static Task<object> GetCustomersProjects(int iCustomerId,DbModel iDb)
        {
            var retObj = await iDb.Project.Where(x => x.customerId == iCustomerId).
                Select(x => new { id = x.id, name = x.name , sheetCount = x.Task.FirstOrDefault().WorkSheet.Count}).ToListAsync();
            return retObj;
        }
    }
}