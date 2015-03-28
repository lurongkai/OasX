using OasX.Infrastructure;
using OasX.Service.Interfaces;

namespace OasX.Service.Impl
{
    public class ExerciseService : IExerciseService
    {
        private OasXContext _OasXContext;

        public ExerciseService(OasXContext OasXContext) {
            _OasXContext = OasXContext;
        }
    }
}