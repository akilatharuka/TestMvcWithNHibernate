using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.DAL.Implementations;
using Domain.DAL.Interfaces;
using Domain.Entities;

namespace ItwPublic.Controllers
{
    public class TestingController : Controller
    {
        /// <summary>
        /// <see cref="ICreateCommand{TEntity}"/> instance.
        /// </summary>
        private ICreateCommand<Article> createQuery1;

        /// <summary>
        /// <see cref="ICreateCommand{TEntity}"/> instance.
        /// </summary>
        private ICreateCommand<Category> createQuery2;

        private UnitOfWork unitOfWork;

        public TestingController(
            ICreateCommand<Article> createQuery1,
            ICreateCommand<Category> createQuery2,
            IUnitOfWork unitOfWork)
        {
            this.createQuery1 = createQuery1;
            this.createQuery2 = createQuery2;
            this.unitOfWork = (UnitOfWork)unitOfWork;
        }

        public ActionResult Indexer()
        {
            var barginBasin = new Category { Name = "GIT", Created = DateTime.Now, Modified = DateTime.Now };

            var daisy = new Article { Title = "Git 1", Created = DateTime.Now, Modified = DateTime.Now };
            var jack = new Article { Title = "Git 2", Created = DateTime.Now, Modified = DateTime.Now };

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