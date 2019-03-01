using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrenLandAnalysis
{
    //Farm field coordinate representing a single coordinate space or meter area in the total land area
    class FarmFieldCoord
    { 
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public FarmFieldCoord(int x, int y)
        {
            X = x;
            Y = y;         
        }

        /// <summary>
        /// X coordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y coordinate
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        ///Bool representing if this node is a barren land
        /// </summary>
        public bool IsBarren { get; set; }

        /// <summary>
        /// Bool representing if this node is already visited
        /// </summary>
        public bool isVisited { get; set; }
    }
}
