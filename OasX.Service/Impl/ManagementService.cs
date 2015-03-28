using System;
using System.Collections.Generic;
using System.Linq;
using OasX.Infrastructure;
using OasX.Service.Interfaces;

namespace OasX.Service.Impl
{
    public class ManagementService : IManagementService
    {
        private OasXContext _OasXContext;

        public ManagementService(OasXContext OasXContext) {
            _OasXContext = OasXContext;
        }

        public IEnumerable<Domain.Application.News> GetTopNews(int count) {
            return _OasXContext.News
                .OrderByDescending(n => n.PublishedDate)
                .Take(count);
        }

        public Domain.Application.News GetNews(Guid newsId) {
            throw new NotImplementedException();
        }

        public Guid CreateNews(Domain.Application.News news) {
            _OasXContext.News.Add(news);
            _OasXContext.SaveChanges();

            return news.NewsId;
        }

        public void ModifyNews(Guid newsId, Domain.Application.News news) {
            var old = _OasXContext.News.Find(newsId);
            old.Content = news.Content;
            old.Title = news.Title;
            old.PublishedDate = DateTime.Now;

            _OasXContext.SaveChanges();
        }

        public void DeleteNews(Guid newsId) {
            var old = _OasXContext.News.Find(newsId);
            _OasXContext.News.Remove(old);
            _OasXContext.SaveChanges();
        }

        public void CreateTeacher(Domain.Teacher teacher) {
            _OasXContext.Teachers.Add(teacher);
            _OasXContext.SaveChanges();
        }

        public void CreateStudent(Domain.Student student) {
            _OasXContext.Students.Add(student);
            _OasXContext.SaveChanges();
        }

        public void SubscribeCourse(Guid studentId, string courseId) {
            _OasXContext.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            var student = _OasXContext.Students.Find(studentId);
            var course = _OasXContext.Courses.Find(courseId);

            student.Subscribe(course);

            _OasXContext.SaveChanges();
        }

        public void AssigningCourse(Guid teacherId, string courseId) {
            var teacher = _OasXContext.Teachers.Find(teacherId);
            var course = _OasXContext.Courses.Find(courseId);

            teacher.Teach(course);

            _OasXContext.SaveChanges();
        }
    }
}