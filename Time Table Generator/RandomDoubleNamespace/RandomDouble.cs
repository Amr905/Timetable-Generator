using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Generator.RandomizerNamespace
{
    public static class Randomizer
    {
        private static Random RandomVar = new Random();

        public static double NextDouble()
        {
            return RandomVar.NextDouble();
        }
        public static int Next(int maximumValue)
        {
            return RandomVar.Next(maximumValue);
        }

    }
}
