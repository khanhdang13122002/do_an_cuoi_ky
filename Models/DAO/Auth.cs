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
           /* khong nen dung == dung equal */
           //dùng == dễ gây ra sql introjection (đánh cắp dữ liệu) ví dụ or 1=1(thế này bằng với select * fom table)=> mất dữ liệu 
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
       /* ham nay lay ra use (neuco thi se khong dk duoc))*/
       //ok chưa?
        public Users getUserByEmails(string email)
        {
            return db_.Users.Where(us => us.email.Equals(email)).FirstOrDefault();
        }
    }
}