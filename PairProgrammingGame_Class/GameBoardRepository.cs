using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairProgrammingGame_Class
{
    public class GameBoardRepository
    {
        //int max_x = 25;
        //int max_y = 25;
        //List<GamePiece>[,] _gameBoard = new List<GamePiece>[max_x, max_y];
        int maxX = 4;
        int maxY = 4;
        //List<GamePiece>[,] _gameBoard = new List<GamePiece>[maxX, maxY];
        List<GamePiece>[,] _gameBoard = new List<GamePiece>[5, 5];

        private readonly Random _random = new Random();

        public void PlaceEmptyListsInGameBoard()
        {
            for (int y = 0; y <= maxY; y++)
            {
                for (int x = 0; x <= maxX; x++)
                {
                    _gameBoard[x, y] = new List<GamePiece>();
                }
            }
        }

        public void AssignRandomCoordinates(GamePiece gamePiece)
        {
            gamePiece.XCoord = RandomNumber(0, maxX);
            gamePiece.YCoord = RandomNumber(0, maxY);
            Console.WriteLine(gamePiece);
        }

        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }



        public void PlacePieceOnGameBoard(GamePiece gamePiece)
        {
            _gameBoard[gamePiece.XCoord, gamePiece.YCoord].Add(gamePiece);
        }

    }
}
