using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairProgrammingGame_Class
{
    public class GameBoardRepository
    {
        int drofsnarLivesRemaining;
        bool foundDrofsnarInList = false;

        Player drofsnarState = new Player("", 0, 0, 0, false,false,3,0,0);

        int maxX = 1;
        int maxY = 1;
        List<GamePiece>[,] _gameBoard = new List<GamePiece>[2, 2];

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
            //Console.WriteLine(gamePiece);
        }

        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }



        public void PlacePieceOnGameBoard(GamePiece gamePiece)
        {
            Console.WriteLine($"Placing {gamePiece.Name} on the game board at coordinates {gamePiece.XCoord} , {gamePiece.YCoord}");

            _gameBoard[gamePiece.XCoord, gamePiece.YCoord].Add(gamePiece);


            if (gamePiece.Name.Contains("Drofsnar"))
            {
                Player drofsnarPiece = (Player)gamePiece;
                drofsnarLivesRemaining = drofsnarPiece.NumberLives;
            }
        }

        public void MoveTillDead()
        {
            while (drofsnarLivesRemaining > 0)
            {
                
                
                MovePieces();
                EvaluateAndScore();
                ResetAllMoveSwitches();
            }

        }

        public void MovePieces()
        {
            Console.ReadLine();
            Console.WriteLine("Moving pieces randomly - one position in any direction");
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    bool running = true;
                    while (running)
                    {
                        if (_gameBoard[x, y].Count > 0)
                        {
                            GamePiece currentpiece = _gameBoard[x, y][0];
                            if (!currentpiece.WasMoved)
                            {
                                Console.WriteLine($"Coordinates of {currentpiece.Name} before move: {currentpiece.XCoord}, {currentpiece.YCoord}");
                                MovePiece(currentpiece);
                                _gameBoard[x, y].Remove(currentpiece);
                                PlacePieceOnGameBoard(currentpiece);
                                currentpiece.WasMoved = true;
                                Console.WriteLine($"Coordinates of {currentpiece.Name} after move: {currentpiece.XCoord}, {currentpiece.YCoord}");

                            } else
                            {
                                Console.WriteLine("Piece has already been moved");
                                running = false;
                            }
                        } else
                        {
                            Console.WriteLine($"No more items in game space {x}, {y}");
                            running = false;
                        }
                    }
                }

            }
        }

        private void MovePiece(GamePiece piece)
        {
            int direction = RandomNumber(0, 3);
            switch (direction)
            {
                case 0:
                    piece.XCoord += (piece.XCoord > 0) ? -1 : 1; // Left movement
                    break;
                case 1:
                    piece.XCoord += (piece.XCoord < maxX) ? 1 : -1; // Right movement
                    break;
                case 2:
                    piece.YCoord += (piece.YCoord > 0) ? -1 : 1;  // Up movement
                    break;
                default:
                    piece.YCoord += (piece.YCoord < maxY) ? 1 : -1;  // Down movement
                    break;
            }
        }

        public void EvaluateAndScore()
        {
            bool foundHunterInList = false;
            bool foundStopperInList = false;
            Player drofsnarState;

            bool InvincibleHunterInList = false;

            for (int y = 0; y <= maxY; y++)
            {
                for (int x = 0; x <= maxX; x++)
                {
                    Console.WriteLine($"x: {x}, y: {y}");

                    foundHunterInList = CheckListForHunter(_gameBoard[x, y]);
                    foundStopperInList = CheckListForStopper(_gameBoard[x, y]);

                    drofsnarState = CheckListForDrofsnar(_gameBoard[x, y]);

                    if (foundHunterInList)
                    {
                        if (foundStopperInList)
                        {
                            SetStopperSwitches(_gameBoard[x, y]);
                        }
                        else
                        {
                            InvincibleHunterInList = FindInvincibleHunters(_gameBoard[x, y]);
                            if (InvincibleHunterInList && foundDrofsnarInList)
                            {
                                KillDrofsnar(_gameBoard[x, y]);
                            }
                        }
                    }
                    else if (foundDrofsnarInList)
                    {
                        ScoreDrofsnar(_gameBoard[x, y], drofsnarState);
                    }

                    foreach (GamePiece pieceInList in _gameBoard[x, y])
                    {
                        Console.WriteLine(pieceInList.Name);
                    }
                    Console.ReadLine();
                }
            }
        }

        public void ScoreDrofsnar(List<GamePiece> cell, Player currentDrofsnar)
        {

            Console.WriteLine($"Begin scoring. Drofsnar's score is {currentDrofsnar.PointsCounter}");
            Console.ReadLine();

            int i = 0;
            while(i < cell.Count)
            {
                bool removed = false;

                if (cell[i].Name.Contains("Hunter"))
                {
                    Hunter hunterPiece = (Hunter)cell[i];
                    if (hunterPiece.StoppedCount > 0)
                    {
                        currentDrofsnar.PointsCounter +=  2 ^ (currentDrofsnar.HunterCount) * hunterPiece.Points;
                        currentDrofsnar.HunterCount += 1;
                        hunterPiece.IsEliminated = true;
                        cell.Remove(hunterPiece);
                        i = 0;
                        removed = true;
                        Console.WriteLine($"Drofsnar has now chomped {currentDrofsnar.HunterCount} Hunters. Drofsnar's score is {currentDrofsnar.PointsCounter}");
                        Console.ReadLine();
                    }
                }
                else
                {
                    if (!cell[i].Name.Contains("Stopper") && !cell[i].Name.Contains("Drofsnar"))
                    {
                        currentDrofsnar.PointsCounter += cell[i].Points;
                        cell[i].IsEliminated = true;
                        cell.Remove(cell[i]);
                        i = 0;
                        removed = true;
                        Console.WriteLine($"Drofsnar caught a {cell[i].Name}. Drofsnar's score is {currentDrofsnar.PointsCounter}");
                          Console.ReadLine();
                    }
                    else
                    {
                        i++;
                    }
                }

            }
        }

        public bool CheckListForHunter(List<GamePiece> gameBoardCell)
        {
            var firstMatch = gameBoardCell.FirstOrDefault(i => i.Name.Contains("Hunter"));

            if (firstMatch != null)
            {
                Console.WriteLine("A Bird Hunter is in this list");
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool CheckListForStopper(List<GamePiece> gameBoardCell)
        {
            var firstMatch = gameBoardCell.FirstOrDefault(i => i.Name.Contains("Stopper"));

            if (firstMatch != null)
            {
                Console.WriteLine("A Stopper is in this list");
                return true;
            }
            else
            {
                return false;
            }

        }

        public Player CheckListForDrofsnar(List<GamePiece> gameBoardCell)
        {
            for (int drofIndex = 0; drofIndex < gameBoardCell.Count; drofIndex++)
            {
                if (gameBoardCell[drofIndex].Name.Contains("Drofsnar"))
                {
                    Player drofsnarPiece = (Player)gameBoardCell[drofIndex];
                    foundDrofsnarInList = true;


                    return drofsnarPiece;
                }
            }
            return null;

        }

        public void SetStopperSwitches(List<GamePiece> listOfPieces)
        {
            foreach (GamePiece pieceInList in listOfPieces)
            {
                if (pieceInList.Name.Contains("Hunter"))
                {
                    Hunter hunterPiece = (Hunter)pieceInList;
                    hunterPiece.StoppedCount = 3;
                    Console.WriteLine($"Hunter {hunterPiece.Name} stopper is {hunterPiece.StoppedCount}");
                }
            }
        }


        public bool FindInvincibleHunters(List<GamePiece> listOfPieces)
        {
            int invincibleHunterCount = 0;
            foreach (GamePiece pieceInList in listOfPieces)
            {
                if (pieceInList.Name.Contains("Hunter"))
                {
                    Hunter hunterPiece = (Hunter)pieceInList;
                    if (hunterPiece.StoppedCount == 0)
                    {
                        invincibleHunterCount += 1;
                        Console.WriteLine("There's an invincible Hunter in this List");
                    }
                    else
                    {
                        Console.WriteLine($"Hunter {hunterPiece.Name}'s stopper count is {hunterPiece.StoppedCount}");
                        hunterPiece.StoppedCount -= 1;
                    }
                }
                Console.WriteLine(pieceInList.Name);
            }
            if (invincibleHunterCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void KillDrofsnar(List<GamePiece> listOfPieces)
        {
            foreach (GamePiece pieceInList in listOfPieces)
            {
                if (pieceInList.Name.Contains("Drofsnar"))
                {
                    Player playerPiece = (Player)pieceInList;
                    playerPiece.NumberLives -= 1;
                    drofsnarLivesRemaining -= 1;
                    Console.WriteLine($"Drofsnar now has {playerPiece.NumberLives} lives");
                }
            }

        }


        public void ResetAllMoveSwitches()
        {
            for (int y = 0; y <= maxY; y++)
            {
                for (int x = 0; x <= maxX; x++)
                {
                    for (int i = 0; i < _gameBoard[x, y].Count; i++)
                    {
                        GamePiece gamePiece = _gameBoard[x, y][i];
                        gamePiece.WasMoved = false;
                    }
                        
                }
            }
        }

    }
}
