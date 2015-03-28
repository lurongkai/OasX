using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OasX.Domain;
using OasX.Domain.Application;
using OasX.Membership;
using OasX.Models.Admin;
using OasX.Service.Interfaces;

namespace OasX.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IManagementService _managementService;
        private readonly ICourseService _courseService;
        private readonly OasXUserManager _userManager;

        public AdminController(ICourseService courseService,
            IManagementService managementService,
            OasXUserManager userManager) {
            _courseService = courseService;
            _managementService = managementService;
            _userManager = userManager;
        }

        public ActionResult Index() {
            return View();
        }

        [HttpGet]
        public ActionResult PublishNews() {
            return View();
        }

        [HttpPost]
        public ActionResult PublishNews(PublishNewsViewModel publishNewsViewModel) {
            if (ModelState.IsValid) {
                var news = new News {Title = publishNewsViewModel.Title, Content = publishNewsViewModel.Content, PublishedDate = DateTime.Now};
                _managementService.CreateNews(news);
                return RedirectToAction("Index");
            }

            return View(publishNewsViewModel);
        }

        [HttpGet]
        public ActionResult CreateTeacher() {
            var courses = _courseService.GetAllCourses();
            ViewBag.Courses = new SelectList(courses, "CourseId", "CourseName");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateTeacher(CreateTeacherViewModel teacherViewModel) {
            if (ModelState.IsValid) {
                var teacher = new OasXIdentityUser(teacherViewModel.Username);
                var result = await _userManager.CreateAsync(teacher, teacherViewModel.Password);
                if (result.Succeeded) {
                    _userManager.AddToRole(teacher.Id, "Teacher");
                    _managementService.CreateTeacher(new Teacher {MemberId = new Guid(teacher.Id)});
                    _managementService.AssigningCourse(new Guid(teacher.Id), teacherViewModel.CourseId);
                    return RedirectToAction("Index");
                }

                AddErrors(result);
            }

            var courses = _courseService.GetAllCourses();
            ViewBag.Courses = new SelectList(courses, "CourseId", "CourseName");
            return View(teacherViewModel);
        }

        [HttpGet]
        public ActionResult CreateCourse() {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCourse(CreateCourseViewModel courseViewModel) {
            if (ModelState.IsValid) {
                var course = new Course
                {
                    CourseId = courseViewModel.CourseAbbr,
                    CourseName = courseViewModel.CourseName,
                    Description = courseViewModel.Description
                };

                _courseService.CreateCourse(course);
                return RedirectToAction("Index");
            }

            return View(courseViewModel);
        }

        private void AddErrors(IdentityResult result) {
            foreach (var error in result.Errors) {
                ModelState.AddModelError("", error);
            }
        }
    }
}