using System.Reflection.Metadata.Ecma335;

namespace MainWindow;

public class Move
{
    private int computerMove;
    private int playerMove;
    public string validationResult;
    private string key;

    public void MakePlayerMove(int n)
    {
        Console.Write("Enter your move: ");
        string input = Console.ReadLine();
        if (input.Equals("?"))
        {
            validationResult = "?";
            return;
        }
        bool result = int.TryParse(input, out playerMove);
        if (result && playerMove <= n)
        {
            if (playerMove == 0)
            {
                validationResult = "Break";
            }
            else if (playerMove <= n)
            {
                validationResult = "Ok";
            }
            return;
        }
        validationResult = "Continue";
    }

    public void MakeComputerMove(int n)
    {
        RandomGenerator randomGenerator = new();
        var randomNumber = randomGenerator.Next(0, n);
        computerMove = randomNumber;
    }

    public void PrintMoves(List<string> moves)
    {
        Console.WriteLine($"Your move: {moves[playerMove - 1]}");
        Console.WriteLine($"Computer move: {moves[computerMove]}");
    }

    public void GenerateHmac(List<string> moves)
    {
        HmacGenerator generator = new();
        
        Console.WriteLine($"HMAC key: {generator.GenerateHmac(moves[computerMove], key)}");
    }

    public void GenerateKey()
    {
        RandomKeyGenerator generator = new();
        key = generator.GenerateKey();
        Console.WriteLine($"HMAC: {key}");
    }

    public int GetPlayerMove() => playerMove;
    public int GetComputerMove() => computerMove;
}