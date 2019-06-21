using MotoKS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MotoKS.Controllers
{
    public class CarsController : Controller
    {
        public ActionResult Index()
        {
            using (var ctx = new Context())
            {
                List<SelectListItem> brands = new List<SelectListItem>();

                foreach (var i in ctx.Brands.OrderBy(x => x.Brand))
                    brands.Add(new SelectListItem { Text = i.Brand, Value = i.ID.ToString() });

                ViewBag.data3 = brands;

                List<SelectListItem> stan = new List<SelectListItem>();
                stan.Add(new SelectListItem { Text = "Wszystkie", Value = "1" });
                stan.Add(new SelectListItem { Text = "Nowe", Value = "2" });
                stan.Add(new SelectListItem { Text = "Używane", Value = "2" });

                ViewBag.data4 = stan;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Search(string marka = "", string model = "", int Rok_od = 0, int Rok_do = 0, int Cena_od = 0, int Cena_do = 0, string stan = "", int Silnik_od = 0, int Silnik_do = 0, int Moc_od = 0, int Moc_do = 0, Cars c = null)
        {
            using (var ctx = new Context())
            {
                IQueryable<Cars> cars = ctx.Cars.OrderByDescending(x => x.DateAdded);

                if (!string.IsNullOrEmpty(marka))
                    cars = cars.Where(x => x.Brand.Brand == marka);

                if (!string.IsNullOrEmpty(model))
                    cars = cars.Where(x => x.CarModel.Model == model);

                if (Rok_od != 0)
                    cars = cars.Where(x => x.ProdDate >= Rok_od);

                if (Rok_do != 0)
                    cars = cars.Where(x => x.ProdDate <= Rok_do);

                if (Cena_od != 0)
                    cars = cars.Where(x => x.Price_ >= Cena_od);

                if (Cena_do != 0)
                    cars = cars.Where(x => x.Price_ >= Cena_do);

                if (stan == "2")
                    cars = cars.Where(x => x.State == State.Nowy);

                if (stan == "3")
                    cars = cars.Where(x => x.State == State.Używany);

                if (Silnik_od != 0)
                    cars = cars.Where(x => x.Engine >= Silnik_od);

                if (Silnik_do != 0)
                    cars = cars.Where(x => x.Engine <= Silnik_do);

                if (Moc_od != 0)
                    cars = cars.Where(x => x.bHP >= Moc_od);

                if (Moc_do != 0)
                    cars = cars.Where(x => x.bHP >= Moc_do);

                if (c.Damaged.ToString() != "Uszkodzony")
                    cars = cars.Where(x => x.Damaged == c.Damaged);

                if (c.Type.ToString() != "Typ")
                    cars = cars.Where(x => x.Type == c.Type);

                if (c.Fuel.ToString() != "Paliwo")
                    cars = cars.Where(x => x.Fuel == c.Fuel);

                if (c.Gearbox.ToString() != "Skrzynia biegów")
                    cars = cars.Where(x => x.Gearbox == c.Gearbox);

                if (c.Drive.ToString() != "Napęd")
                    cars = cars.Where(x => x.Drive == c.Drive);

                if (cars != null)
                    Session["Cars"] = cars;

                return View();
            }
        }
    }
}