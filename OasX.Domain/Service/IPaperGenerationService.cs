using System;
using System.Collections.Generic;

namespace OasX.Domain.Service
{
    public interface IPaperGenerationService
    {
        IEnumerable<Guid> GenerateSingleSelectionQuestions(int count);
        IEnumerable<Guid> GenerateMultipleSelectionQuestions(int count);
        IEnumerable<Guid> GenerateSubjectiveSelectionQuestions(int count);
    }
}