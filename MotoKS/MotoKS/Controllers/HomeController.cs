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
        public ActionResult Index(string marka = "", string model = "", int Rok_od = 0, int Rok_do = 0, int Cena_od = 0, int Cena_do = 0, string Stan = "")
        {
            using (var ctx = new Context())
            {
                var cars = ctx.Cars.OrderByDescending(x => x.DateAdded).ToList();

                if (!string.IsNullOrEmpty(marka))
                    cars = ctx.Cars.Where(x => x.Brand.Brand == marka).ToList();

                if (!string.IsNullOrEmpty(model))
                    cars = ctx.Cars.Where(x => x.CarModel.Model == model).ToList();

                if (Rok_od != 0)
                    cars = ctx.Cars.Where(x => x.ProdDate >= Rok_od).ToList();

                if (Rok_do != 0)
                    cars = ctx.Cars.Where(x => x.ProdDate <= Rok_do).ToList();

                if (Cena_od != 0)
                    cars = ctx.Cars.Where(x => x.Price_ >= Cena_od).ToList();

                if (Cena_do != 0)
                    cars = ctx.Cars.Where(x => x.Price_ <= Cena_do).ToList();

                if (!string.IsNullOrEmpty(Stan))
                {
                    if(Stan == "Nowe")
                        cars = ctx.Cars.Where(x => x.State == State.Nowy).ToList();
                    else if(Stan == "Używane")
                        cars = ctx.Cars.Where(x => x.State == State.Używany).ToList();
                }

                if(cars != null)
                    Session["Cars2"] = cars;

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