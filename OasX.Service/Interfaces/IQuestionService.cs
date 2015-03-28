using System;
using System.Collections.Generic;
using OasX.Domain;

namespace OasX.Service.Interfaces
{
    public interface IQuestionService
    {
        IEnumerable<SelectableQuestion> GetAllSelectableQuestion(string courseId, Guid subjectId);
        IEnumerable<SubjectiveQuestion> GetAllSubjectiveQuestion(string courseId, Guid subjectId);

        SubjectiveQuestion GetSubjectiveQuestion(Guid questionId);

        Question GetQuestion(Guid questionId);

        Guid CreateSelectableQuestion(Guid subjectId, SelectableQuestion question);
        Guid CreateSubjectiveQuestion(Guid subjectId, SubjectiveQuestion question);

        void DeleteQuestion(Guid questionId);
    }
}