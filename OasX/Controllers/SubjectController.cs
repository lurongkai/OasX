using System;
using System.Web.Mvc;
using OasX.Domain;
using OasX.Models.Subject;
using OasX.Service.Interfaces;

namespace OasX.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class SubjectController : Controller
    {
        private ICourseService _courseService;

        public SubjectController(ICourseService courseService) {
            _courseService = courseService;
        }

        public ActionResult Index(string courseId) {
            var subjects = _courseService.GetCourseSubjects(courseId);
            var pinnedSubjects = _courseService.GetCoursePinSubjects(courseId);
            var viewModel = new SubjectViewModel(subjects, pinnedSubjects);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create(string courseId) {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string courseId, Subject subject) {
            _courseService.CreateSubject(courseId, subject);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult PinSubject(string courseId, Guid subjectId, string pinName) {
            _courseService.PinSubject(courseId, subjectId, pinName);
            return RedirectToAction("Index");
        }

        public ActionResult UnPinSubject(string courseId, Guid subjectId) {
            _courseService.UnPinSubject(courseId, subjectId);
            return RedirectToAction("Index");
        }

        public ActionResult SetForSimulation(string courseId, Guid subjectId) {
            _courseService.SetSimulation(courseId, subjectId);
            return RedirectToAction("Index");
        }
    }
}