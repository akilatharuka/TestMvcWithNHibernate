using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.DAL.Implementations;
using Domain.DAL.Interfaces;
using Domain.Entities;

namespace ItwAdmin.Controllers
{
    public class ArticleController : Controller
    {
        private static UnitOfWork unitOfWork = new UnitOfWork();
        private ICreateCommand<Article> createQuery = new CreateCommand<Article>(unitOfWork);
        private ICreateCommand<Category> createQuery2 = new CreateCommand<Category>(unitOfWork);

        // GET: Article
        public ActionResult Index()
        {
            return View();
        }
    }
}