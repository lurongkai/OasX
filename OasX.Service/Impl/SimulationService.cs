using System;
using System.Linq;
using OasX.Domain.Service;
using OasX.Infrastructure;
using OasX.Service.Interfaces;

namespace OasX.Service.Impl
{
    public class SimulationService : ISimulationService
    {
        private OasXContext _OasXContext;

        public SimulationService(OasXContext OasXContext) {
            _OasXContext = OasXContext;
        }

        public Paper GeneratePaper(string courseId, string style) {
            var bag = new QuestionTicketBag();
            bag.SingleSelectionQuestions = _OasXContext.SelectableQuestions
                .Where(q => q.BelongTo.CourseId == courseId)
                .Where(q => q.Options.Count(o => o.IsRight) == 1)
                .Select(q => new QuestionTicket {QuestionId = q.QuestionId, Score = q.Score, Degree = q.Degree});
            bag.MultipleSelectionQuestions = _OasXContext.SelectableQuestions
                .Where(q => q.BelongTo.CourseId == courseId)
                .Where(q => q.Options.Count(o => o.IsRight) > 1)
                .Select(q => new QuestionTicket {QuestionId = q.QuestionId, Score = q.Score, Degree = q.Degree});
            bag.SubjectiveQuestions = _OasXContext.SubjectiveQuestions
                .Where(q => q.BelongTo.CourseId == courseId)
                .Select(q => new QuestionTicket {QuestionId = q.QuestionId, Score = q.Score, Degree = q.Degree});
            
            var singleCount = 20;
            var multipleCount = 20;
            var subjectiveCount = 5;

            IPaperGenerationService service = null;
            if (style.ToLower() == "random") {
                service = new RandomPaperGenerationService(bag);
                singleCount = 0;
                multipleCount = 0;
            }
            if (style.ToLower() == "simple") {
                service = new SimplePaperGenerationService(bag);
                subjectiveCount = 0;
            }

            if (service == null) {
                throw new InvalidOperationException("wrong style.");
            }

            var paper = new Paper();
            var singles = service.GenerateSingleSelectionQuestions(singleCount).ToArray();
            var multiples = service.GenerateMultipleSelectionQuestions(multipleCount).ToArray();
            var subjectives = service.GenerateSubjectiveSelectionQuestions(subjectiveCount).ToArray();
            paper.SingleQuestions = _OasXContext.SelectableQuestions.Where(q => singles.Contains(q.QuestionId)).ToList();
            paper.MultipleQuestions = _OasXContext.SelectableQuestions.Where(q => multiples.Contains(q.QuestionId)).ToList();
            paper.SubjectiveQuestions = _OasXContext.SubjectiveQuestions.Where(q => subjectives.Contains(q.QuestionId)).ToList();

            return paper;
        }
    }
}