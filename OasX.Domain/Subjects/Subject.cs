using System;

namespace OasX.Domain
{
    public class Subject : IAggregateRoot<Subject>
    {
        public Subject() {
            SubjectId = Guid.NewGuid();
        }

        public Guid SubjectId { get; set; }
        public string Name { get; set; }
        public bool ForSimulation { get; set; }

        public virtual Course BelongTo { get; set; }
    }
}