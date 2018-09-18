using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Text;

namespace SVTemple.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Charity()
        {
            ViewBag.Message = "Your Charity page.";

            return View();
        }
        public ActionResult History()
        {
            ViewBag.Message = "Your History page.";

            return View();
        }
        public ActionResult Events()
        {
            ViewBag.Message = "Your Events page.";

            return View();
        }
        [HttpGet]
        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUs(string name, string email, string phone, string subject, string message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                string frommail = "XXX@gmail.com"; // ConfigurationManager.AppSettings["FromMailAddress"];
                string password = "XXXXX"; // ConfigurationManager.AppSettings["password"];
                mail.To.Add("XXX@gmail.com"); // ConfigurationManager.AppSettings["ToMailAddress"];
                mail.From = new MailAddress(frommail);
                mail.Subject = subject;
                StringBuilder sb = new StringBuilder();
                sb.Append("<br/>Name: " + name);
                sb.Append("<br/>Email Id: " + email);
                sb.Append("<br/>Phone No: " + phone);
                sb.Append("<br/>Message: " + message);
                
                string Body = "Hi, <br/><br/> A new enquiry by user. Detail is as follows:<br/><br/> " + sb.ToString() + "<br/><br/>Thanks";
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                //SMTP Server Address of gmail
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential(frommail, password);
                // Smtp Email ID and Password For authentication
                //smtp.EnableSsl = true;
                smtp.Send(mail);
                ViewBag.Message = "Thank you for contacting us.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error............";
            }
            return View();
        }
    }
}