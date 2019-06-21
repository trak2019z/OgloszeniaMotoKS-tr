using MotoKS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MotoKS.Controllers
{
    public class AddController : Controller
    {
        public ActionResult Index()
        {
            using (var ctx = new Context())
            {
                if (Session["user"] == null)
                    return RedirectToAction("Index", "SignUp");

                List<SelectListItem> brands = new List<SelectListItem>();

                foreach (var i in ctx.Brands.OrderBy(x => x.Brand))
                    brands.Add(new SelectListItem { Text = i.Brand, Value = i.ID.ToString() });

                ViewBag.data2 = brands;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(Cars c, string marka, string model, HttpPostedFileBase file, HttpPostedFileBase[] files)
        {
            using (var ctx = new Context())
            {
                Users tmp = (Users)Session["user"];
                Users usr = ctx.Users.Where(x => x.ID == tmp.ID).FirstOrDefault();

                var b = ctx.Brands.Where(x => x.ID.ToString() == marka).FirstOrDefault();
                var md = ctx.CarModels.Where(x => x.ID.ToString() == model).FirstOrDefault();

                var NewFN = string.Format("{0}-{1}{2}", Path.GetFileNameWithoutExtension(file.FileName), Guid.NewGuid().ToString("N"), Path.GetExtension(file.FileName));

                c.Brand = b;
                c.CarModel = md;
                c.MainPhoto = NewFN;
                c.User = usr;

                ctx.Cars.Add(c);

                string path = Path.Combine(Server.MapPath("~/Content/Images"), NewFN);
                file.SaveAs(path);

                Photos ps = null;

                foreach (var f in files.Where(x => x != null))
                {
                    var NewFN2 = string.Format("{0}-{1}{2}", Path.GetFileNameWithoutExtension(f.FileName), Guid.NewGuid().ToString("N"), Path.GetExtension(f.FileName));

                    string paths = Path.Combine(Server.MapPath("~/Content/Images"), NewFN2);
                    f.SaveAs(paths);

                    ps = new Photos
                    {
                        Name = NewFN2,
                        Car = c
                    };

                    ctx.Photos.Add(ps);
                }

                ctx.SaveChanges();
            }

            return RedirectToAction("Index", "Car", new { ID = c.ID });
        }

        public JsonResult GetModel(string marka)
        {
            string models = "";
            using (var ctx = new Context())
            {
                var getmodels = ctx.CarModels.Where(x => x.Brand.ID.ToString() == marka);

                foreach (var i in getmodels)
                    models += "<option value='" + i.ID + "'> " + i.Model + " </option> ";
            }

            return Json(models, JsonRequestBehavior.AllowGet);
        }
    }
}