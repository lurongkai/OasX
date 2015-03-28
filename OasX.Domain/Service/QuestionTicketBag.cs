using System.Collections.Generic;

namespace OasX.Domain.Service
{
    public class QuestionTicketBag
    {
        public IEnumerable<QuestionTicket> SingleSelectionQuestions { get; set; }
        public IEnumerable<QuestionTicket> MultipleSelectionQuestions { get; set; }
        public IEnumerable<QuestionTicket> SubjectiveQuestions { get; set; }
    }
}