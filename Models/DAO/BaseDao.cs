using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final_exam_app.Models.DAO
{
    public class BaseDao
    {
        protected Models.EF.Entities1 db_;
        public BaseDao()
        {
            db_ = new Models.EF.Entities1();

        }
    }
}