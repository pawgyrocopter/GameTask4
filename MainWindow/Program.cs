using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using MainWindow;

var moves = args.Where(x => !x.Equals(" ")).Select(x => x).ToList();
if (moves.Count() % 2 == 0)
{
    Console.WriteLine("Not correct input, try something else");
}

string[,]? helpTable = new string[moves.Count()+1,moves.Count()+1];
helpTable[0, 0] = "M";
for (int i = 1; i <= moves.Count(); i++)
{
    helpTable[0, i] = moves[i-1];
    helpTable[i, 0] = moves[i-1];
    helpTable[i, i] = "D";
    
}
for (int i = 1; i <= moves.Count(); i++)
{
    for (int j = (i + 1) % 7; j <= i + (moves.Count() - 1) / 2; j++)
    {
        if (j > moves.Count)
        {
            helpTable[i, j - moves.Count()] = "W";
            helpTable[j - moves.Count(), i] = "L";
        }
        else
        {
            helpTable[i, j] = "W";
            helpTable[j, i] = "L";
        }
    }
}

   
for (int i = 0; i <= moves.Count(); i++)
{
    for (int j = 0; j <= moves.Count(); j++)
    {
        Console.Write(helpTable[i,j] + ' ');
    }
    Console.WriteLine("");
}

for (int i = 0; i < moves.Count; i++)
{
    Console.WriteLine($"{i+1})  " + moves[i]);
}
Console.WriteLine("Input your move");
var consoleKey = Console.ReadKey();
Console.WriteLine($"Your move: {moves[int.Parse(consoleKey.KeyChar.ToString())-1]}");

RandomGenerator randomGenerator = new();
var randomNumber = randomGenerator.Next(0, moves.Count());
Console.WriteLine(randomNumber);


using RandomNumberGenerator rng = RandomNumberGenerator.Create();
byte[] keyBytes = new byte[32];
rng.GetBytes(keyBytes);
var key = string.Concat(Array.ConvertAll(keyBytes, b => b.ToString("X2"))).ToLower();
Console.WriteLine(key);

var signatureBytes = System.Text.Encoding.UTF8.GetBytes(randomNumber.ToString());
var shaKeyBytes = System.Text.Encoding.UTF8.GetBytes(key);
var shaAlgorithm = new System.Security.Cryptography.HMACSHA256(shaKeyBytes);
var signatureHashBytes = shaAlgorithm.ComputeHash(signatureBytes);
var signatureHashHex = string.Concat(Array.ConvertAll(signatureHashBytes, b => b.ToString("X2"))).ToLower();
Console.WriteLine(signatureHashHex);

