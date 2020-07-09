using PairProgrammingGame_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairProgrammingGame_Console
{
    public class PlayGameUI
    {
        private readonly GameBoardRepository _gameBoardRepo = new GameBoardRepository();

        public void Run()
        {

            _gameBoardRepo.PlaceEmptyListsInGameBoard();
            PopulateGameboard();
            _gameBoardRepo.MoveTillDead();
            //_gameBoardRepo.ReportResults(); 

        }

        public void PopulateGameboard()
        {
            GamePiece birdOne = new GamePiece("Bird 1", 10, 0, 0, false, false);
            GamePiece birdTwo = new GamePiece("Bird 2", 10, 0, 0, false, false);
            GamePiece birdThree = new GamePiece("Bird 3", 10, 0, 0, false, false);
            GamePiece birdFour = new GamePiece("Bird 4", 10, 0, 0, false, false);
            GamePiece CrestedIbis = new GamePiece("Crested Ibis", 100, 0, 0, false, false);
            GamePiece GreatKiskudee = new GamePiece("Great Kiskudee", 300, 0, 0, false, false);
            GamePiece RedCrossbill = new GamePiece("Red Crossbill", 500, 0, 0, false, false);
            GamePiece RedNeckedPhalarope = new GamePiece("Red-Necked Phalarope", 700, 0, 0, false, false);
            GamePiece EveningGrosbeak = new GamePiece("Evening Grosbeak", 1000, 0, 0, false, false);
            GamePiece GreaterPrairieChicken = new GamePiece("Greater Prairie Chicken", 2000, 0, 0, false, false);
            GamePiece IcelandGull = new GamePiece("Iceland Gull", 3000, 0, 0, false, false);
            GamePiece OrangeBelliedParrot = new GamePiece("Orange-Bellied Parrot", 5000, 0, 0, false, false);
            Hunter BirdHunterOne = new Hunter("Bird Hunter 1", 200, 0, 0, false, false, 0);
            Hunter BirdHunterTwo = new Hunter("Bird Hunter 2", 200, 0, 0, false, false, 0);
            Hunter BirdHunterThree = new Hunter("Bird Hunter 3", 200, 0, 0, false, false, 0);
            Hunter BirdHunterFour = new Hunter("Bird Hunter 4", 200, 0, 0, false, false, 0);
            GamePiece Stopper = new GamePiece("Stopper", 0, 0, 0, false, false);
            Player Grofsnar = new Player("Grofsnar", 0, 0, 0, false, false, 3, 0, 0);

            _gameBoardRepo.AssignRandomCoordinates(birdOne);
            _gameBoardRepo.AssignRandomCoordinates(birdTwo);
            _gameBoardRepo.AssignRandomCoordinates(birdThree);
            _gameBoardRepo.AssignRandomCoordinates(birdFour);
            _gameBoardRepo.AssignRandomCoordinates(CrestedIbis);
            _gameBoardRepo.AssignRandomCoordinates(GreatKiskudee);
            _gameBoardRepo.AssignRandomCoordinates(RedCrossbill);
            _gameBoardRepo.AssignRandomCoordinates(RedNeckedPhalarope);
            _gameBoardRepo.AssignRandomCoordinates(EveningGrosbeak);
            _gameBoardRepo.AssignRandomCoordinates(GreaterPrairieChicken);
            _gameBoardRepo.AssignRandomCoordinates(IcelandGull);
            _gameBoardRepo.AssignRandomCoordinates(OrangeBelliedParrot);
            _gameBoardRepo.AssignRandomCoordinates(BirdHunterOne);
            _gameBoardRepo.AssignRandomCoordinates(BirdHunterTwo);
            _gameBoardRepo.AssignRandomCoordinates(BirdHunterThree);
            _gameBoardRepo.AssignRandomCoordinates(BirdHunterFour);
            _gameBoardRepo.AssignRandomCoordinates(Stopper);
            _gameBoardRepo.AssignRandomCoordinates(Grofsnar);


            _gameBoardRepo.PlacePieceOnGameBoard(birdOne);
            _gameBoardRepo.PlacePieceOnGameBoard(birdTwo);
            _gameBoardRepo.PlacePieceOnGameBoard(birdThree);
            _gameBoardRepo.PlacePieceOnGameBoard(birdFour);
            _gameBoardRepo.PlacePieceOnGameBoard(CrestedIbis);
            _gameBoardRepo.PlacePieceOnGameBoard(GreatKiskudee);
            _gameBoardRepo.PlacePieceOnGameBoard(RedCrossbill);
            _gameBoardRepo.PlacePieceOnGameBoard(RedNeckedPhalarope);
            _gameBoardRepo.PlacePieceOnGameBoard(EveningGrosbeak);
            _gameBoardRepo.PlacePieceOnGameBoard(GreaterPrairieChicken);
            _gameBoardRepo.PlacePieceOnGameBoard(IcelandGull);
            _gameBoardRepo.PlacePieceOnGameBoard(OrangeBelliedParrot);
            _gameBoardRepo.PlacePieceOnGameBoard(BirdHunterOne);
            _gameBoardRepo.PlacePieceOnGameBoard(BirdHunterTwo);
            _gameBoardRepo.PlacePieceOnGameBoard(BirdHunterThree);
            _gameBoardRepo.PlacePieceOnGameBoard(BirdHunterFour);
            _gameBoardRepo.PlacePieceOnGameBoard(Stopper);
            _gameBoardRepo.PlacePieceOnGameBoard(Grofsnar);

        }
    }
}
