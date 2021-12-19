using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using MainWindow;

var moves = args.Where(x => !x.Equals(" ")).Select(x => x).ToList();
if (moves.Count() % 2 == 0)
{
    Console.WriteLine("Not correct input, try something else");
}

GameLoop gameLoop = new();
gameLoop.StarGame(moves);




RandomGenerator randomGenerator = new();
var randomNumber = randomGenerator.Next(0, moves.Count());
Console.WriteLine(moves[randomNumber]);


RandomKeyGenerator keyGenerator = new();
string key = keyGenerator.GenerateKey();
Console.WriteLine(key);

HmacGenerator hmacGenerator = new();
string hmac = hmacGenerator.GenerateHmac(moves[randomNumber], key);
Console.WriteLine(hmac);


