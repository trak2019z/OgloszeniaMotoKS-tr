using MotoKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MotoKS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var ctx = new Context())
            {
                List<SelectListItem> brands = new List<SelectListItem>();

                foreach (var i in ctx.Brands.OrderBy(x => x.Brand))
                    brands.Add(new SelectListItem { Text = i.Brand, Value = i.ID.ToString() });

                ViewBag.data1 = brands;
            }

            return View();
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