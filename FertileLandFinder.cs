using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrenLandAnalysis
{
    /// <summary>
    /// Class to find available fertile land in sorted order
    /// </summary>
    public class FertileLandFinder
    {
        /// <summary>
        /// Maximum X coordinate
        /// </summary>
        const int X_MAX = 400;
        /// <summary>
        /// Maximum Y coordinate
        /// </summary>
        const int Y_MAX = 600;
        /// <summary>
        /// Total available land
        /// </summary>
        FarmFieldCoord[,] totalLand;
        /// <summary>
        /// Fertile Area 
        /// </summary>
        List<int> fertileAreaMap;        
        /// <summary>
        /// Barrenlands
        /// </summary>
        HashSet<int[]> barrenLandRects;        

        /// <summary>
        /// Constructor
        /// </summary>
        public FertileLandFinder()
        {
            totalLand = new FarmFieldCoord[X_MAX, Y_MAX];
            fertileAreaMap = new List<int>();            
            barrenLandRects = new HashSet<int[]>();            
        }

        /// <summary>
        /// Find the fertile land areas by not considering the provided barren lands
        /// </summary>
        /// <returns>list of fertile areas</returns>
        public List<int> FindFertileLandAreas()
        {
            //string[] coordSets = new string[] { "0 292 399 307" };            
            string[] coordSets = new string[] { "48 192 351 207", "48 392 351 407", "120 52 135 547", "260 52 275 547" };
            bool success = ReadCoordinates(coordSets);
            CreateTotalLand();
            MarkBarrenLands();
            GetConnectedFertileLands();
            return fertileAreaMap;
        }

        /// <summary>
        /// Read the barrenland coordinates
        /// </summary>
        /// <param name="coordSets"></param>
        /// <returns>if reading was successful</returns>
        public bool ReadCoordinates(string[] coordSets)
        {
            bool parseSuccessful = true;
            try
            {                
                foreach (string coords in coordSets)
                {
                    if (coords != string.Empty)
                    {
                        string[] coord = coords.Split(' ');

                        int[] temp = new int[] {int.Parse(coord[0]), int.Parse(coord[1]),
                        int.Parse(coord[2]), int.Parse(coord[3])};

                        barrenLandRects.Add(temp);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while parsing the input, quitting" + ex.InnerException.ToString());
                parseSuccessful = false;
            }
            return parseSuccessful;
        }


        /// <summary>
        /// Create total available land as per th provided X and Y max. values
        /// </summary>
        public void CreateTotalLand()
        {
            for (int i = 0; i < X_MAX; i++)
            {
                for (int j = 0; j < Y_MAX; j++)
                {
                    FarmFieldCoord co = new FarmFieldCoord(i, j);
                    totalLand[i, j] = co;
                }
            }
        }

        /// <summary>
        /// Mark Barren lands 
        /// </summary>
        public void MarkBarrenLands()
        {
            foreach (int[] barrenLandRect in barrenLandRects)
            {
                for (int i = barrenLandRect[0]; i <= barrenLandRect[2]; i++)
                {
                    for (int j = barrenLandRect[1]; j <= barrenLandRect[3]; j++)
                    {
                        totalLand[i, j].IsBarren = true;
                    }
                }
            }
        }

        /// <summary>
        /// Get the avialable fertile lands
        /// </summary>
        public void GetConnectedFertileLands()
        {
            for (int i = 0; i < X_MAX; i++)
            {
                for (int j = 0; j < Y_MAX; j++)
                {
                    FarmFieldCoord coord = totalLand[i,j];
                    if (!coord.isVisited)
                    {
                        int fertileLand = FillFertileArea(i, j);
                        if (fertileLand != 0)
                        {
                            fertileAreaMap.Add(fertileLand);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Check the node is visited or not
        /// </summary>
        /// <param name="coord"></param>
        /// <returns></returns>
        private bool CheckCoordNodeUnVisited(FarmFieldCoord coord)
        {
            if (coord.isVisited)
            {
                return false;
            }
            coord.isVisited = true;

            return true;
        }

        /// <summary>
        /// Fill the fertile area from the start point of x and y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>return connected fertile land</returns>
        private int FillFertileArea(int x, int y)
        {
            int fertileCoord = 0;
            Queue<FarmFieldCoord> coordQueue = new Queue<FarmFieldCoord>();
            coordQueue.Enqueue(totalLand[x, y]);

            while (coordQueue.Count > 0)
            {
                FarmFieldCoord coord = coordQueue.Dequeue();

                if (CheckCoordNodeUnVisited(coord))
                {                    
                    if (coord.IsBarren)
                    {
                        continue;
                    }
                    fertileCoord++;
                    if (coord.X > 0 && !totalLand[coord.X - 1, coord.Y].isVisited)
                    {
                        coordQueue.Enqueue(totalLand[coord.X - 1, coord.Y]);
                    }
                    if (coord.X < X_MAX - 1 && !totalLand[coord.X + 1, coord.Y].isVisited)
                    {
                        coordQueue.Enqueue(totalLand[coord.X + 1, coord.Y]);
                    }
                    if (coord.Y > 0 && !totalLand[coord.X, coord.Y - 1].isVisited)
                    {
                        coordQueue.Enqueue(totalLand[coord.X, coord.Y - 1]);
                    }
                    if (coord.Y < Y_MAX - 1 && !totalLand[coord.X, coord.Y + 1].isVisited)
                    {
                        coordQueue.Enqueue(totalLand[coord.X, coord.Y + 1]);
                    }
                }
            }
            return fertileCoord;
        }

        public List<int> GetFertileAreaMap()
        {
            return fertileAreaMap;
        }
    }
}
