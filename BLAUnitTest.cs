using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BarrenLandAnalysis
{
    /// <summary>
    /// Unit Testing
    /// </summary>
    [TestFixture]
    public class BLAUnitTest
    {
        [Test]
        public void BarrenLandAnalysisTest1()
        {
            List<int> result = new List<int>() { 116800, 116800 };   
                       
            FertileLandFinder fertileLandFinder = new FertileLandFinder();

            string[] coordSets = new string[] { "0 292 399 307" };

            fertileLandFinder.ReadCoordinates(coordSets);

            fertileLandFinder.CreateTotalLand();

            fertileLandFinder.MarkBarrenLands();

            fertileLandFinder.GetConnectedFertileLands();

            List<int> fertileLand = fertileLandFinder.GetFertileAreaMap();

            Assert.IsTrue(result.Equals(fertileLand));
        }

        [Test]
        public void BarrenLandAnalysisTest2()
        {
            List<int> result = new List<int>() { 22816, 192608 };

            FertileLandFinder fertileLandFinder = new FertileLandFinder();

            string[] coordSets = new string[] { "48 192 351 207", "48 392 351 407", "120 52 135 547", "260 52 275 547" };

            fertileLandFinder.ReadCoordinates(coordSets);

            fertileLandFinder.CreateTotalLand();

            fertileLandFinder.MarkBarrenLands();

            fertileLandFinder.GetConnectedFertileLands();

            List<int> fertileLand = fertileLandFinder.GetFertileAreaMap();

            Assert.IsTrue(result.Equals(fertileLand));
        }
    }
}
