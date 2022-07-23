using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using URLShortner.Models;
using URLShortner.Exceptions;
using System.Security.Cryptography;
using System.Text;

namespace URLShortner.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext _myDbContext = new MyDbContext();
        const string randomCodeGenerator = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GenerateShortURL(string longURL)
        {
            var code = GenerateCode();

            while (_myDbContext.URLDetails.ToList().Any(url => url.ShortURL == code))
            {
                code = GenerateCode();
            }
            var urlDetail = new URLDetails()
            {
                LongURL = longURL,
                ShortURL = code,
                CreatedDate = DateTime.Now
            };
            _myDbContext.URLDetails.Add(urlDetail);
            try
            {
                _myDbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedValidationException(e);
                throw newException;
            }


            return Json(new { code = code });

        }

        public ActionResult Error404()
        {
            return View();
        }

        public ActionResult RedirectToOriginalURL(string code)
        {
            var longURL = _myDbContext.URLDetails.Where(x => x.ShortURL == code)?.FirstOrDefault().LongURL;
            if (!string.IsNullOrEmpty(longURL))
                return Redirect(longURL);
            return RedirectToAction("Error404");
        }
        public string GenerateCode()
        {
            return randomCodeGenerator.Substring(new Random().Next(0, randomCodeGenerator.Length - 1), new Random().Next(2, 6));
        }

    }
}