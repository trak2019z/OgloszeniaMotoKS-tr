using MotoKS.Models;
using System.Linq;
using System.Web.Mvc;

namespace MotoKS.Controllers
{
    public class ConvController : Controller
    {
        public ActionResult Index(int? ID)
        {
            using (var ctx = new Context())
            {
                var c = ctx.Conversations.Where(x => x.ID == ID).FirstOrDefault();

                if (c != null)
                    return View(c);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult New(int? ID, string nowe)
        {
            using (var ctx = new Context())
            {
                Users tmp = (Users)Session["user"];
                Users usr = ctx.Users.Where(x => x.ID == tmp.ID).FirstOrDefault();

                Conversations c = new Conversations
                {
                    Buyer = usr,
                    Car = ctx.Cars.Where(x => x.ID == ID).FirstOrDefault(),
                    New = true
                };
                c.Count++;

                ctx.Conversations.Add(c);

                Messages m = new Messages
                {
                    Message = nowe,
                    Who = false,
                    Conv = c
                };

                ctx.Messages.Add(m);

                var favs = ctx.Favs.Where(x => x.Car.ID == c.Car.ID && x.User.ID == usr.ID).FirstOrDefault();

                if(favs == null)
                {
                    Favs f = new Favs
                    {
                        Car = c.Car,
                        User = usr
                    };

                    ctx.Favs.Add(f);
                }

                ctx.SaveChanges();
            }

            return RedirectToAction("Index", "Conv", new { ID = ID });
        }

        [HttpPost]
        public ActionResult Add(int? ID, string nowe)
        {
            using (var ctx = new Context())
            {
                Users tmp = (Users)Session["user"];
                Users usr = ctx.Users.Where(x => x.ID == tmp.ID).FirstOrDefault();

                Conversations c = ctx.Conversations.Where(x => x.ID == ID).FirstOrDefault();
                c.Count++;

                Messages m = new Messages
                {
                    Message = nowe,
                    Who = usr.ID == c.Car.User.ID ? true : false,
                    Conv = c
                };

                ctx.Messages.Add(m);

                ctx.SaveChanges();
            }

            return RedirectToAction("Index", "Conv", new { ID = ID });
        }
    }
}