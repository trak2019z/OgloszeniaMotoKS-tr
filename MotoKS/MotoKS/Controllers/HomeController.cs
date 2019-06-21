using MotoKS.Models;
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

        [HttpPost]
        public ActionResult Index(string marka, string model, int Rok_od, int Rok_do, int Cena_od, int Cena_do, string Stan)
        {
            using (var ctx = new Context())
            {
                IQueryable<Cars> cars = ctx.Cars.OrderByDescending(x => x.DateAdded);

                if (!string.IsNullOrEmpty(marka))
                    cars = ctx.Cars.Where(x => x.Brand.Brand == marka);

                if (!string.IsNullOrEmpty(model))
                    cars = ctx.Cars.Where(x => x.CarModel.Model == model);

                if (!string.IsNullOrEmpty(Rok_od.ToString()))
                    cars = ctx.Cars.Where(x => x.ProdDate >= Rok_od);

                if (!string.IsNullOrEmpty(Rok_do.ToString()))
                    cars = ctx.Cars.Where(x => x.ProdDate <= Rok_do);

                if (!string.IsNullOrEmpty(Cena_od.ToString()))
                    cars = ctx.Cars.Where(x => x.Price_ >= Cena_od);

                if (!string.IsNullOrEmpty(Cena_do.ToString()))
                    cars = ctx.Cars.Where(x => x.Price_ >= Cena_do);

                if (!string.IsNullOrEmpty(Stan))
                {
                    if(Stan == "Nowe")
                        cars = ctx.Cars.Where(x => x.State == State.Nowy);
                    else if(Stan == "Używane")
                        cars = ctx.Cars.Where(x => x.State == State.Używany);
                }

                ViewBag.Cars2 = cars;

                return RedirectToAction("Index", "Cars");
            }
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