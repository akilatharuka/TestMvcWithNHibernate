using Domain.DAL.Implementations;
using Domain.DAL.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItwAdmin.Controllers
{
    public class testController : Controller
    {
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private ICreateCommand<Article> createQuery = new CreateCommand<Article>(unitOfWork);
        private ICreateCommand<Category> createQuery2 = new CreateCommand<Category>(unitOfWork);
        // GET: test
        public ActionResult Index()
        {
            var barginBasin = new Category { Name = "Bargin Basin", Created = DateTime.Now, Modified = DateTime.Now };

            var daisy = new Article { Title = "Daisy", Created=DateTime.Now, Modified=DateTime.Now};
            var jack = new Article { Title = "Jack", Created = DateTime.Now, Modified = DateTime.Now };

            barginBasin.Articles.Add(daisy);
            barginBasin.Articles.Add(jack);

            daisy.Category = barginBasin;
            jack.Category = barginBasin;

            createQuery2.Execute(barginBasin);
            unitOfWork.Commit();

            return View();
        }
    }
}