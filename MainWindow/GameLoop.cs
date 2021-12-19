using System.Net;

namespace MainWindow;

public class GameLoop
{
    public void StarGame(List<string> moves)
    {
        
        Menu menu = new();
        Move move = new Move();
        while (true)
        {
            menu.PrintMenu(moves);
            int newMove = move.MakeMove();
            if (newMove == -1)
            {
                continue;
            }else if (newMove == 0) break;
            
            
        }
    }
}