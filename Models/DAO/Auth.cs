using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using final_exam_app.Models.EF;
namespace final_exam_app.Models.DAO
{
    public class Auth:BaseDao
    {
        //hàm đăng nhập
        public Users Login(string email_,string pass_) {
            return db_.Users.Where(us => us.email.Equals(email_)&&us.password_.Equals(pass_)).FirstOrDefault();
        }
        //Hàm đăng ký
        public bool Res(string email_,string pass_)
        {
            try
            {
                Users us_ = new Users
                {
                    email = email_,
                    password_ = pass_
                };
                db_.Users.Add(us_);
                db_.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }

        }
        public Users getUserByEmails(string email)
        {
            return db_.Users.Where(us => us.email.Equals(email)).FirstOrDefault();
        }
    }
}