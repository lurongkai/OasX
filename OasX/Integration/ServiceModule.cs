using Autofac;
using OasX.Service.Impl;
using OasX.Service.Interfaces;

namespace OasX.Integration
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<CourseService>().As<ICourseService>().InstancePerRequest();
            builder.RegisterType<ExerciseService>().As<IExerciseService>().InstancePerRequest();
            builder.RegisterType<ManagementService>().As<IManagementService>().InstancePerRequest();
            builder.RegisterType<QuestionService>().As<IQuestionService>().InstancePerRequest();
            builder.RegisterType<SimulationService>().As<ISimulationService>().InstancePerRequest();
        }
    }
}