using System;

namespace BattleshipGame.Domain.Utils
{
    //TODO: Move to common project
    public class Helper
    {
        static Random _r = new Random();

        public static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T) v.GetValue(_r.Next(v.Length));
        }
    }
}