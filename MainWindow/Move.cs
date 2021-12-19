namespace MainWindow;

public class Move
{
    public int MakeMove()
    {
        string input = Console.ReadLine();
        int move;
        bool result = int.TryParse(input, out move);
        if (result)
        {
            return move;
        }
        return -1;
    }
}