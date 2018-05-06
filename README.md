# TaskScheduler
This is a simple task scheduler made by Ronen Beniaminov as an interview task. Made with angular 1 at client side, C# with Entity Framework, web forms project with ApiController, DBcontext per request concept. CreateDB.sql and InsertData should run for DB usage.

WebApplication2/Views - Index.html - entry point
WebApplication2/Scripts - JS scripts.
WebApplication2/Controllers - ApiController - each controller inherit from ApiAbstractController class which return EF model context.
                              Implements DBcontext per request. Web from do not support ApiController by default. Pay attention to                                       WebApiConfig.cs under App_Start
WebApplication2/Models - contain EF model. Each class has an partial class which contain logic.                              
