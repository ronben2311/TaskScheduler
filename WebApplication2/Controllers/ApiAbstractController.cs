using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    //Each controller will inherit from this class. which will return DB context. Context per request.
    public abstract class ApiAbstractController : ApiController
    {
        private  DbModel mDb;

        protected DbModel DB
        {
            get
            {
                if (mDb == null)
                {
                    mDb = new DbModel();
                }
                return mDb;
            }
        }
    }
}
