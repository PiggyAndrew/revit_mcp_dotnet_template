using System.Collections.Generic;

namespace NET.APP.API
{
    public static class Constants
    {
        public static List<string> TrueValues { get; } = new List<string> { "1", "true", "yes", "y", "t" };

        public static List<string> FalseValues { get; } = new List<string> { "0", "false", "no", "n", "f" };
    }
}
