namespace MainWindow;

public class ChooseWinner
{
    public string MatchResult(int playerMove, int computerMove, string[,] helpTable)
    {
        if (helpTable[playerMove, computerMove+1].Equals("W")) return "You win!";
        if (helpTable[playerMove, computerMove+1].Equals("L")) return "You lost!";
        return "It's draw!";
        
    }
}