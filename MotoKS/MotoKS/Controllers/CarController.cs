using MotoKS.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MotoKS.Controllers
{
    public class CarController : Controller
    {
        public ActionResult Index(int? ID)
        {
            using (var ctx = new Context())
            {
                Users tmp = (Users)Session["user"];
                Users usr = tmp == null ? null : ctx.Users.
                    Where(x => x.ID == tmp.ID).FirstOrDefault();

                var car = ctx.Cars.Where(x => x.ID == ID).FirstOrDefault();

                if (car != null)
                {
                    if (usr == null || car.User.ID != usr.ID)
                        car.Views++;

                    ctx.SaveChanges();

                    return View(car);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int? ID)
        {
            using (var ctx = new Context())
            {
                Users tmp = (Users)Session["user"];
                Users usr = ctx.Users.Where(x => x.ID == tmp.ID).FirstOrDefault();

                var car = ctx.Cars.Where(x => x.ID == ID).FirstOrDefault();

                if (car != null && car.User.Mail == usr.Mail)
                    return View(car);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Fav(int? ID)
        {
            using (var ctx = new Context())
            {
                Users tmp = (Users)Session["user"];
                Users usr = ctx.Users.Where(x => x.ID == tmp.ID).FirstOrDefault();

                var car = ctx.Cars.Where(x => x.ID == ID).FirstOrDefault();

                if (car != null && car.User.Mail != usr.Mail)
                {
                    Favs f = new Favs();
                    f.Car = car;
                    f.User = usr;

                    ctx.Favs.Add(f);

                    ctx.SaveChanges();

                    return RedirectToAction("Index", "Car", new { ID = car.ID });
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult NoFav(int? ID)
        {
            using (var ctx = new Context())
            {
                Users tmp = (Users)Session["user"];
                Users usr = ctx.Users.Where(x => x.ID == tmp.ID).FirstOrDefault();

                var car = ctx.Cars.Where(x => x.ID == ID).FirstOrDefault();

                if (car != null && car.User.Mail != usr.Mail)
                {
                    var f = ctx.Favs.Where(x => x.Car.ID == ID && x.User.Mail == usr.Mail).FirstOrDefault();

                    ctx.Favs.Remove(f);

                    ctx.SaveChanges();

                    return RedirectToAction("Index", "Car", new { ID = car.ID });
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int? ID)
        {
            using (var ctx = new Context())
            {
                Users tmp = (Users)Session["user"];
                Users usr = ctx.Users.Where(x => x.ID == tmp.ID).FirstOrDefault();

                var car = ctx.Cars.Where(x => x.ID == ID && x.User.Mail == usr.Mail).FirstOrDefault();

                if (car != null)
                {
                    var photos = ctx.Photos.Where(x => x.Car.ID == car.ID);

                    foreach (var p in photos)
                        ctx.Photos.Remove(p);

                    var conv = ctx.Conversations.Where(x => x.Car.ID == car.ID);

                    foreach (var c in conv)
                    {
                        var msg = ctx.Messages.Where(x => x.Conv == c);

                        foreach (var m in msg)
                            ctx.Messages.Remove(m);

                        ctx.Conversations.Remove(c);
                    }

                    ctx.Cars.Remove(car);

                    ctx.SaveChanges();
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Edit(int? ID, Cars c)
        {
            using (var ctx = new Context())
            {
                Users tmp = (Users)Session["user"];
                Users usr = ctx.Users.Where(x => x.ID == tmp.ID).FirstOrDefault();

                Cars car = ctx.Cars.Where(x => x.ID == ID).FirstOrDefault();

                car.State = c.State;
                car.Type = c.Type;
                car.Damaged = c.Damaged;
                car.ProdDate = c.ProdDate;
                car.Fuel = c.Fuel;
                car.Gearbox = c.Gearbox;
                car.Mileage = c.Mileage;
                car.Drive = c.Drive;
                car.Engine = c.Engine;
                car.bHP = c.bHP;
                car.Price_ = c.Price_;
                car.Negotiable = c.Negotiable;
                car.Registered = c.Registered;
                car.Netto = c.Netto;
                car.VAT = c.VAT;
                car.Leasing = c.Leasing;
                car.OC = c.OC;
                car.Color = c.Color;
                car.Country = c.Country;
                car.FirstOwner = c.FirstOwner;
                car.NoAcc = c.NoAcc;
                car.ASO = c.ASO;
                car.Desc = c.Desc;
                car.City = c.City;
                car.PostCode = c.PostCode;
                car.Phone = c.Phone;

                ctx.SaveChanges();
            }

            return RedirectToAction("Index", "Car", new { ID = ID });
        }
    }
}