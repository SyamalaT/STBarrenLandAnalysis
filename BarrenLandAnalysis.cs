using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrenLandAnalysis
{
    /// <summary>
    /// Main class for the starting point of barren land analysis
    /// </summary>
    class BarrenLandAreaAnalysis
    {
        static void Main(string[] args)
        {
            FertileLandFinder fertileLandFinder = new FertileLandFinder();
            List<int> fertileLands = fertileLandFinder.FindFertileLandAreas();
            //Sort the fertile lands
            fertileLands.Sort();
            foreach(int fertileLand in fertileLands)
            {
                Console.WriteLine(fertileLand);
            }
        }
    }
}
