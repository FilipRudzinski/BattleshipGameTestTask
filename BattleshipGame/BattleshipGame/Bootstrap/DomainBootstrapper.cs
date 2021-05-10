using BattleshipGame.Domain.Factories;

namespace BattleshipGame.Android.Bootstrap
{
    public class DomainBootstrapper
    {
        public static void Bootstrap()
        {
            App.RegisterType<IMatrixFactory, MatrixFactory>();
        }
    }
}