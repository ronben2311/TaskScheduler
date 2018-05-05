using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Controllers.JsonClasses
{
    public class searchWorkSheetJson
    {
        public int projectId { get; set; }
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public string taskPartialName { get; set; }
        public string chosenColumn { get; set; }
        public string orderBy { get; set; }
        public int employeeId { get; set; }
    }

    public class SaveSheetJson
    {
        public int employeeId { get; set; }
        public int sheetId { get; set; }
        public string customerName { get; set; }
        public string projectName { get; set; }
        public DateTime date { get; set; }
        public DateTime newStartHour { get; set; }
        public DateTime newEndHour { get; set; }
        public string newComment { get; set; }
        public int taskId { get; set; }
    }
}