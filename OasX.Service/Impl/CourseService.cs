using System;
using System.Collections.Generic;
using System.Linq;
using OasX.Infrastructure;
using OasX.Service.Interfaces;

namespace OasX.Service.Impl
{
    public class CourseService : ICourseService
    {
        private OasXContext _OasXContext;

        public CourseService(OasXContext OasXContext) {
            _OasXContext = OasXContext;
        }

        public IEnumerable<Domain.Course> GetAllCourses() {
            return _OasXContext.Courses;
        }

        public Domain.Course GetCourse(string courseId) {
            return _OasXContext.Courses.Find(courseId);
        }

        public IEnumerable<Domain.Course> GetStudentCourses(Guid studentId) {
            var student = _OasXContext.Students.Find(studentId);
            return student.SubscribeCourses;
        }

        public Domain.Course GetTeacherTeachCourse(Guid teacherId) {
            var teacher = _OasXContext.Teachers.Find(teacherId);
            return teacher.TeachCourse;
        }

        public string CreateCourse(Domain.Course course) {
            _OasXContext.Courses.Add(course);
            _OasXContext.SaveChanges();

            return course.CourseId;
        }

        public IEnumerable<Domain.Subject> GetCourseSubjects(string courseId) {
            return _OasXContext.Subjects.Where(s => s.BelongTo.CourseId == courseId);
        }

        public Guid CreateSubject(string courseId, Domain.Subject subject) {
            var course = _OasXContext.Courses.Find(courseId);
            if (!_OasXContext.Subjects.Any(s => s.BelongTo.CourseId == courseId)) {
                subject.ForSimulation = true;
            }

            subject.BelongTo = course;
            _OasXContext.Subjects.Add(subject);
            _OasXContext.SaveChanges();
            return subject.SubjectId;
        }

        public void ModifySubject(Guid subjectId, Domain.Subject subject) {
            var old = _OasXContext.Subjects.Find(subjectId);
            old.Name = subject.Name;

            _OasXContext.SaveChanges();
        }

        public void DeleteSubject(Guid subjectId) {
            var old = _OasXContext.Subjects.Find(subjectId);
            _OasXContext.Subjects.Remove(old);

            _OasXContext.SaveChanges();
        }

        public void PinSubject(string courseId, Guid subjectId, string pinName) {
            var course = _OasXContext.Courses.Find(courseId);
            var subject = _OasXContext.Subjects.Find(subjectId);
            course.Pin(subject, pinName);

            _OasXContext.SaveChanges();
        }

        public void UnPinSubject(string courseId, Guid subjectId) {
            var course = _OasXContext.Courses.Find(courseId);
            var subject = _OasXContext.Subjects.Find(subjectId);
            course.UnPin(subject);

            _OasXContext.SaveChanges();
        }

        public IEnumerable<Domain.SubjectPin> GetCoursePinSubjects(string courseId) {
            var course = _OasXContext.Courses.Find(courseId);
            return course.PinSubjects;
        }


        public void SetSimulation(string courseId, Guid subjectId) {
            var subjects = _OasXContext.Subjects.Where(s => s.BelongTo.CourseId == courseId);

            foreach (var subject in subjects) {
                if (subject.SubjectId == subjectId) {
                    subject.ForSimulation = true;
                } else {
                    subject.ForSimulation = false;
                }
            }

            _OasXContext.SaveChanges();
        }
    }
}