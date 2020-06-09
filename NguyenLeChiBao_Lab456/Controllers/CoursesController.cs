using Microsoft.AspNet.Identity;
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


        [Authorize]
        public ActionResult Create()
        {
            var ViewModel = new CoursesViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(ViewModel);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CoursesViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.Categories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
                LecturerID = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryID = viewModel.Category,
                Place = viewModel.Place
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home"); ;
        }
    }
}