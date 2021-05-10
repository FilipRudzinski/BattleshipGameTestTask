using System.Reflection;
using Autofac;
using BattleshipGame.Application.Requests;
using BattleshipGame.Application.ViewModels;
using MediatR;
using MediatR.Pipeline;

namespace BattleshipGame.Android.Bootstrap
{
    public class MainBootstrapper
    {
        public static void Bootstrap()
        {
            var builder = App.GetBuilder();
            App.RegisterType<IMediator, Mediator>();
            App.RegisterType<BattleshipGameViewModel>();
            App.RegisterType<BattleTileViewModel>();

            BuildMediator(builder);
            
            DomainBootstrapper.Bootstrap();
            ApplicationBootstrapper.Bootstrap();
            
            App.BuildContainer();
        }

        private static void BuildMediator(ContainerBuilder builder)
        {
            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
            
            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IRequestExceptionHandler<,,>),
                typeof(IRequestExceptionAction<,>),
                typeof(INotificationHandler<>),
            };
            
            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(typeof(ResetRequest).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }
        }
        
    }
}