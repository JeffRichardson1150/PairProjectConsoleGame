using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairProgrammingGame_Class
{
    public class GameBoardRepository
    {
        int maxX = 2;
        int maxY = 2;
        //List<GamePiece>[,] _gameBoard = new List<GamePiece>[maxX, maxY];
        List<GamePiece>[,] _gameBoard = new List<GamePiece>[3, 3];

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

        public void MoveTillDead()
        {
            // before I develop the actual code, I'm going to test traversing the array and pulling all elements of each list
            //ListEntireBoardAndIDHunters();

            EvaluateAndScore();

        }

        public void EvaluateAndScore()
        {
            bool foundHunterInList = false;
            bool foundStopperInList = false;
            bool foundGrofsnarInList = false;
            bool InvincibleHunterInList = false;

            for (int y = 0; y <= maxY; y++)
            {
                for (int x = 0; x <= maxX; x++)
                {
                    Console.WriteLine($"x: {x}, y: {y}");

                    foundHunterInList = CheckListForHunter(_gameBoard[x, y]);
                    foundStopperInList = CheckListForStopper(_gameBoard[x, y]);
                    Console.WriteLine($"foundHunterInList is {foundHunterInList}");
                    Console.WriteLine($"foundStopperInList is {foundStopperInList}");

                    foundGrofsnarInList = CheckListForGrofsnar(_gameBoard[x, y]);
                    Console.WriteLine($"foundGrofsnarInList is {foundGrofsnarInList}");

                    if (foundHunterInList)
                    {
                        if (foundStopperInList)
                        {
                            SetStopperSwitches(_gameBoard[x, y]);
                        }
                        else
                        {
                            InvincibleHunterInList = FindInvincibleHunters(_gameBoard[x, y]);
                            if (InvincibleHunterInList && foundGrofsnarInList)
                            {
                                KillGrofsnar(_gameBoard[x, y]);
                            }
                        }
                    }

                    foreach (GamePiece pieceInList in _gameBoard[x, y])
                    {
                        Console.WriteLine(pieceInList.Name);
                    }
                    Console.ReadLine();
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

        public bool CheckListForGrofsnar(List<GamePiece> gameBoardCell)
        {
            var firstMatch = gameBoardCell.FirstOrDefault(i => i.Name.Contains("Grofsnar"));

            if (firstMatch != null)
            {
                Console.WriteLine("Grofsnar is in this list");
                return true;
            }
            else
            {
                return false;
            }

        }

        public void SetStopperSwitches(List<GamePiece> listOfPieces)
        {
            foreach (GamePiece pieceInList in listOfPieces)
            {
                if (pieceInList.Name.Contains("Hunter"))
                {
                    Hunter hunterPiece = (Hunter)pieceInList;
                    hunterPiece.StoppedCount = 3;
                }
                Console.WriteLine(pieceInList.Name);
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
                    if (hunterPiece.StoppedCount == 0 )
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

        
        public void KillGrofsnar(List<GamePiece> listOfPieces)
        {
            foreach (GamePiece pieceInList in listOfPieces)
            {
                if (pieceInList.Name.Contains("Grofsnar"))
                {
                    Player playerPiece = (Player)pieceInList;
                    playerPiece.NumberLives -= 1;
                }
                Console.WriteLine($"Grofsnar now has {playerPiece.NumberLives} lives");
            }

        }



        // Lambda expressions that don't work
        // Find items where name contains "seat".
        //Console.WriteLine("\nKillGrofsnar...Find: list item where name contains Grofsnar",
        //    gameBoardCell.Find(x => x.Name.Contains("Grofsnar")));

        //var firstMatch = gameBoardCell.FirstOrDefault(i => i.Name.Contains("Grofsnar"));

        //var firstMatch = gameBoardCell.FirstOrDefault(i => 
        //{  if(i.Name.Contains("Grofsnar"))
        //    {
        //        Player iPlayer = (Player)i;
        //        iPlayer.NumberLives -= 1;
        //        Console.WriteLine($"Grofsnar has {iPlayer.NumberLives} Lives remaining" +
        //            $"");
        //    }
        //}

        //);



        //public void ListEntireBoardAndIDHunters()
        //{

        //    for (int y = 0; y <= maxY; y++)
        //    {
        //        for (int x = 0; x <= maxX; x++)
        //        {
        //            Console.WriteLine($"x: {x}, y: {y}");

        //            List<GamePiece> listInCell = new List<GamePiece>();
        //            listInCell = _gameBoard[x, y];
        //            var firstMatch = listInCell.FirstOrDefault(i => i.Name.Contains("Hunter"));
        //  //var firstMatch = listInCell.FirstOrDefault(i =>
        //  //{
        //  //    i.Name.Contains("Hunter");
        //   //    Console.WriteLine($"i = {i}");
        //  //    return true;
        //  //});
        //            if (firstMatch != null)
        //            {
        //                Console.WriteLine("A Bird Hunter is in this list");
        //            }

        //            foreach (GamePiece pieceInList in _gameBoard[x, y])
        //            {
        //                Console.WriteLine(pieceInList.Name);
        //            }
        //            Console.ReadLine();
        //        }
        //    }
        //}



        //public void ListGameBoardContents()
        //{ 
        //    for (int y = 0; y <= maxY; y++)
        //    {
        //        for (int x = 0; x <= maxX; x++)
        //        {
        //            Console.WriteLine($"x: {x}, y: {y}");
        //            foreach(GamePiece pieceInList in _gameBoard[x, y])
        //            {
        //                Console.WriteLine(pieceInList.Name);
        //            }
        //            Console.ReadLine();
        //        }
        //    }
        //}

    }
}
