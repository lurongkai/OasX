using System;
using System.Collections.Generic;

namespace OasX.Domain
{
    public class SelectableQuestion : Question, IAggregateRoot<SelectableQuestion>
    {
        public SelectableQuestion() {
            QuestionId = Guid.NewGuid();
            Options = new List<Option>();
        }

        public virtual ICollection<Option> Options { get; set; }

        public override int Evaluate() {
            throw new NotImplementedException();
        }
    }
}