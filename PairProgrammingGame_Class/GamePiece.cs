using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairProgrammingGame_Class
{
    public class GamePiece
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public bool WasMoved { get; set; }
        public bool IsEliminated { get; set; }

        public GamePiece() { }
        public GamePiece(string name, int points, int xCoord, int yCoord, bool wasMoved, bool isEliminated)
        {
            Name = name;
            Points = points;
            XCoord = xCoord;
            YCoord = yCoord;
            WasMoved = wasMoved;
            IsEliminated = isEliminated;
        }
    }
}
