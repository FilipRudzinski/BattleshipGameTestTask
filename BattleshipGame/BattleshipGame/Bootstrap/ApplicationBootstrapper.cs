using BattleshipGame.Application;

namespace BattleshipGame.Android.Bootstrap
{
    public class ApplicationBootstrapper
    {
        public static void Bootstrap()
        {
            App.RegisterType<IAppManager, AppManager>();
        }
    }
}