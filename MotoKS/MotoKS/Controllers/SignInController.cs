using MotoKS.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace MotoKS.Controllers
{
    public class SignInController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Gz()
        {
            return View();
        }

        public JsonResult CheckMail(string mail)
        {
            if (mail == "")
                return Json("", JsonRequestBehavior.AllowGet);

            string IsValid = "<span class='glyphicon glyphicon-ban-circle' style='color:red; font-size: 30px' data-toggle='tooltip' title='Nazwa niedostępna'></span>";
            using (var ctx = new Context())
            {
                var check = ctx.Users.Where(x => x.Mail == mail).FirstOrDefault();

                if (check == null)
                    IsValid = "<span class='glyphicon glyphicon-ok' style='color:green; font-size: 30px;' data-toggle='tooltip' title='Nazwa dostępna'></span>";
            }

            return Json(IsValid, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(Users usr)
        {
            using (var ctx = new Context())
            {
                var tmp = ctx.Users.Where(x => x.Mail == usr.Mail).FirstOrDefault();

                if(tmp != null)
                {
                    ViewBag.ErrorMessage = "Konto o podanym adresie e-mail już istnieje";

                    return View();
                }

                const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
                var randNum = new Random();
                var chars = new char[10];
                var allowedCharCount = allowedChars.Length;
                for (var i = 0; i <= 10 - 1; i++)
                {
                    chars[i] = allowedChars[Convert.ToInt32((allowedChars.Length) * randNum.NextDouble())];
                }
                string salt = new string(chars);

                usr.Salt = salt;

                byte[] bytes = Encoding.Unicode.GetBytes(usr.Password);
                byte[] src = Encoding.Unicode.GetBytes(salt);
                byte[] dst = new byte[src.Length + bytes.Length];
                Buffer.BlockCopy(src, 0, dst, 0, src.Length);
                Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
                HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
                byte[] inArray = algorithm.ComputeHash(dst);

                byte[] originalBytes;
                byte[] encodedBytes;
                MD5 md5;
                md5 = new MD5CryptoServiceProvider();
                originalBytes = Encoding.Default.GetBytes(Convert.ToBase64String(inArray));
                encodedBytes = md5.ComputeHash(originalBytes);

                usr.Password = BitConverter.ToString(encodedBytes);

                ctx.Users.Add(usr);

                ctx.SaveChanges();
            }

            return View("Gz");
        }
    }
}