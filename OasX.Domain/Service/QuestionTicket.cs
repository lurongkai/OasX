using System;

namespace OasX.Domain.Service
{
    public class QuestionTicket
    {
        public Guid QuestionId { get; set; }
        public int Score { get; set; }
        public double Degree { get; set; }
    }
}