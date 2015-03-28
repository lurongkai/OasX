using System;
using System.Collections.Generic;
using System.Linq;
using OasX.Infrastructure;
using OasX.Service.Interfaces;

namespace OasX.Service.Impl
{
    public class QuestionService : IQuestionService
    {
        private OasXContext _OasXContext;

        public QuestionService(OasXContext OasXContext) {
            _OasXContext = OasXContext;
        }

        public IEnumerable<Domain.SelectableQuestion> GetAllSelectableQuestion(string courseId, Guid subjectId) {
            return _OasXContext.SelectableQuestions.Where(q => q.Subject.SubjectId == subjectId);
        }

        public IEnumerable<Domain.SubjectiveQuestion> GetAllSubjectiveQuestion(string courseId, Guid subjectId) {
            return _OasXContext.SubjectiveQuestions.Where(q => q.Subject.SubjectId == subjectId);
        }

        public Domain.SubjectiveQuestion GetSubjectiveQuestion(Guid questionId) {
            return _OasXContext.SubjectiveQuestions.Find(questionId);
        }

        public Domain.Question GetQuestion(Guid questionId) {
            throw new NotImplementedException();
        }

        public Guid CreateSelectableQuestion(Guid subjectId, Domain.SelectableQuestion question) {
            var subject = _OasXContext.Subjects.Find(subjectId);
            question.Subject = subject;
            question.BelongTo = subject.BelongTo;
            _OasXContext.SelectableQuestions.Add(question);

            _OasXContext.SaveChanges();
            return question.QuestionId;
        }

        public Guid CreateSubjectiveQuestion(Guid subjectId, Domain.SubjectiveQuestion question) {
            var subject = _OasXContext.Subjects.Find(subjectId);
            question.Subject = subject;
            question.BelongTo = subject.BelongTo;
            _OasXContext.SubjectiveQuestions.Add(question);

            _OasXContext.SaveChanges();
            return question.QuestionId;
        }

        public void DeleteQuestion(Guid questionId) {
            var selectable = _OasXContext.SelectableQuestions.FirstOrDefault(q => q.QuestionId == questionId);
            var subjective = _OasXContext.SubjectiveQuestions.FirstOrDefault(q => q.QuestionId == questionId);

            if (selectable != null) {
                _OasXContext.SelectableQuestions.Remove(selectable);
            }
            if (subjective != null) {
                _OasXContext.SubjectiveQuestions.Remove(subjective);
            }

            _OasXContext.SaveChanges();
        }
    }
}