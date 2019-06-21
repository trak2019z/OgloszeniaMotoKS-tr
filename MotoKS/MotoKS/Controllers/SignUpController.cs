using MotoKS.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace MotoKS.Controllers
{
    public class SignUpController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Users usr)
        {
            using (var ctx = new Context())
            {
                var user = ctx.Users.Where(x => x.Mail == usr.Mail).FirstOrDefault();

                if (user == null)
                    ViewBag.ErrorMessage = "Niepoprawna nazwa użytkownika lub hasło";
                else
                {
                    byte[] bytes = Encoding.Unicode.GetBytes(usr.Password);
                    byte[] src = Encoding.Unicode.GetBytes(user.Salt);
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
                    string encoded = BitConverter.ToString(encodedBytes);

                    var user2 = ctx.Users.Where(x => x.Mail == usr.Mail && x.Password == encoded).FirstOrDefault();

                    if (user2 == null)
                        ViewBag.ErrorMessage = "Niepoprawna nazwa użytkownika lub hasło";
                    else
                    {
                        HttpContext.Session.Add("user", user2);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return View();
        }

        public ActionResult SignOff()
        {
            HttpContext.Session.Remove("user");

            return RedirectToAction("Index", "Home");
        }
    }
}