using Autofac;
using BattleshipGame.Application;

namespace BattleshipGame.Android.Bootstrap
{
    public class ApplicationBootstrapper
    {
        public static void Bootstrap()
        {
            App.RegisterTypeAsSingleton<IAppManager, AppManager>();
        }
    }
}