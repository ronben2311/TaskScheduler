# TaskScheduler
using:
client side: angular 1 
Server side: C# with Entity Framework, DBcontext per request concept. ApiController.
Data base: SqlServer, Database creation with realtion between tables. Index usage. 

CreateDB.sql and InsertData should run for DB usage.

WebApplication2/Views - Index.html - entry point

WebApplication2/Scripts - JS scripts.
AjaxCalls.js - Factory, returns an object which holds all ajax calls.
userValidation.js and workSheet.js share data by sharedData factory which declared at index.js
Routing enabled by $routeProvider declared at index.js.

WebApplication2/Controllers - ApiController - each controller inherit from ApiAbstractController class which return EF model context.
Implements DB context per request. WebFroms do not support ApiController by default. Pay attention to                                       WebApiConfig.cs under App_Start

WebApplication2/Models - Contain EF model. Each class has an partial class that contain its logic.




