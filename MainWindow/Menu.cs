namespace MainWindow;

public class Menu
{
    public void PrintMenu(List<string> moves)
    {
        for (int i = 0; i < moves.Count(); i++)
        {
            Console.WriteLine($"{i+1} - {moves[i]}");
        }
        Console.WriteLine($"0 - exit");
        Console.WriteLine($"? - help");
    }
}