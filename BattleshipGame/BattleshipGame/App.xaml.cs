using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using BattleshipGame.Android.Bootstrap;
using BattleshipGame.Android.View;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BattleshipGame.Android
{
    public partial class App
    {
        static IContainer _container;
        static readonly ContainerBuilder builder = new ContainerBuilder();
        
        public App()
        {
            InitializeComponent();
            AppBootstrapper.Bootstrap();
            MainPage = new GamePage();
        }
        
        

        protected override void OnStart()
        {
            
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static ContainerBuilder GetBuilder()
        {
            return builder;
        }
        
        public static void RegisterType<T>() where T : class
        {
            builder.RegisterType<T>();
        }
        
        

        public static void RegisterType<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            builder.RegisterType<T>().As<TInterface>();
        }

        public static void RegisterTypeWithParameters<T>(Type param1Type, object param1Value, Type param2Type, string param2Name) where T : class
        {
            builder.RegisterType<T>()
                .WithParameters(new List<Parameter>()
                {
                    new TypedParameter(param1Type, param1Value),
                    new ResolvedParameter(
                        (pi, ctx) => pi.ParameterType == param2Type && pi.Name == param2Name,
                        (pi, ctx) => ctx.Resolve(param2Type))
                });
        }

        public static void RegisterTypeWithParameters<TInterface, T>(Type param1Type, object param1Value, Type param2Type, string param2Name) where TInterface : class where T : class, TInterface
        {
            builder.RegisterType<T>()
                .WithParameters(new List<Parameter>()
                {
                    new TypedParameter(param1Type, param1Value),
                    new ResolvedParameter(
                        (pi, ctx) => pi.ParameterType == param2Type && pi.Name == param2Name,
                        (pi, ctx) => ctx.Resolve(param2Type))
                }).As<TInterface>();
        }

        public static void BuildContainer()
        {
            _container = builder.Build();
            
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
