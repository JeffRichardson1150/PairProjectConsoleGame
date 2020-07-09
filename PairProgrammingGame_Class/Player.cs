using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairProgrammingGame_Class
{
    public class Player : GamePiece
    {
        public int NumberLives { get; set; }
        public int HunterCount { get; set; }
        public int PointsCounter { get; set; }

        public Player() { }
        public Player(string name, int points, int xCoord, int yCoord, bool wasMoved, bool isEliminated, int numberLives, int hunterCount, int pointsCounter)
        {
            Name = name;
            Points = points;
            XCoord = xCoord;
            YCoord = yCoord;
            WasMoved = wasMoved;
            IsEliminated = isEliminated;
            NumberLives = numberLives;
            HunterCount = hunterCount;
            PointsCounter = pointsCounter;
        }

    }
}
