using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairProgrammingGame_Class
{
    public class Hunter : GamePiece
    {
        public int StoppedCount { get; set; }

        public Hunter() { }
        public Hunter(string name, int points, int xCoord, int yCoord, bool wasMoved, bool isEliminated, int stoppedCount)
        {
            Name = name;
            Points = points;
            XCoord = xCoord;
            YCoord = yCoord;
            WasMoved = wasMoved;
            IsEliminated = isEliminated;
            StoppedCount = stoppedCount;
        }

    }

}
