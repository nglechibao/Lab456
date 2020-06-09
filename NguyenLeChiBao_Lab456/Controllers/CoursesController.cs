using NguyenLeChiBao_Lab456.Models;
using NguyenLeChiBao_Lab456.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NguyenLeChiBao_Lab456.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Courses
        
        public ActionResult Create()
        {
            var ViewModel = new CouresViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(ViewModel);
        }
    }
}