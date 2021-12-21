using System.Globalization;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace MainWindow;

public class GameLoop
{
    public void StarGame(List<string> moves)
    {
        Menu menu = new();
        HelpTable helpTable = new();
        string[,] table = helpTable.CreateTable(moves);
        while (true)
        {
            Console.Clear();
            Move move = new Move();
            ChooseWinner winner = new();
            move.GenerateKey();
            menu.PrintMenu(moves);
            move.MakePlayerMove(moves.Count());
            if (move.validationResult.Equals("Continue"))
            {
                continue;
            }else if (move.validationResult.Equals("Break")) break;

            if (move.validationResult.Equals("?"))
            {
                helpTable.PrintTable(table, moves.Count);
                Console.ReadKey();
                continue;
            }
            move.MakeComputerMove(moves.Count());
            move.PrintMoves(moves);
            Console.WriteLine(winner.MatchResult(move.GetPlayerMove(), move.GetComputerMove(), table));
            move.GenerateHmac(moves);
            Console.ReadKey();
        }  
        
    }
}