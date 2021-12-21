using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using MainWindow;

var moves = args.Where(x => !x.Equals(" ")).Select(x => x).ToList();
bool isUnique = moves.Distinct().Count() == moves.Count();
if (moves.Count() % 2 == 0 || moves.Count() < 3 || !isUnique)
{
    Console.WriteLine("Not correct input, try something else:");
    Console.WriteLine("Try dotnet run 1 2 3 \n or dotnet run q w e r t \n or rock paper scis ");
    return;
}

GameLoop gameLoop = new();
gameLoop.StarGame(moves);