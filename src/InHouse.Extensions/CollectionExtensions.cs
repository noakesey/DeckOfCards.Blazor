using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace InHouse.Extensions
{
    /// <summary>
    /// Reusable functions for other projects, distributed via package.
    /// </summary>
    public static class CollectionExtensions
    {
        //Make sure each thread has it's own random number generator
        [ThreadStatic] private static Random Local;

        public static Random ThreadSafeRandom
        {
            get
            {
                //The Default seed uses Environment.TickCount
                //https://referencesource.microsoft.com/#mscorlib/system/random.cs
                //Not a good idea for a prodution requirement as it's possible to predict
                //https://www.developer.com/tech/article.php/10923_616221_3/How-We-Learned-to-Cheat-at-Online-Poker-A-Study-in-Software-Security.htm
                
                return Local ?? (Local = new Random());
            }
        }

        //Based on Fisher Yates and reviewed on Stackoverflow
        //https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        //https://stackoverflow.com/questions/273313/randomize-a-listt
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> items)
        {
            List<T> list = items.ToList();

            int target = list.Count;
            while (target > 1)
            {
                target--;
                int source = ThreadSafeRandom.Next(target + 1);
                T temp = list[source];
                list[source] = list[target];
                list[target] = temp;
            }

            return list;
        }
    }
}
