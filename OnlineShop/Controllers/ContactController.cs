using Common;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Send(string name, string mobile, string address, string email, string content)
        {
            var feedback = new Feedback();
            feedback.Name = name;
            feedback.Email = email;
            feedback.Address = address;
            feedback.CreatedTime = DateTime.Now;
            feedback.Phone = mobile;
            feedback.Content = content;
            var id = new FeedbackDao().InsertFeedback(feedback);
            if(id > 0)
            {
                //send email
                string noidung = System.IO.File.ReadAllText(Server.MapPath("~/assets/client/template/newcontact.html"));
                noidung = noidung.Replace("{{CustomerName}}", name);
                noidung = noidung.Replace("{{Phone}}", mobile);
                noidung = noidung.Replace("{{Email}}", email);
                noidung = noidung.Replace("{{Address}}", address);
                noidung = noidung.Replace("{{Content}}", content);
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new MailHelper().SendMail(toEmail, "Liên hệ mới từ OnlineShop", noidung);
                new MailHelper().SendMail(email, "Liên hệ mới từ OnlineShop", noidung);
                return Json(new
                {
                    status = true
                });
                

            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
    }
}