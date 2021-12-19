namespace MainWindow;

public class HelpTablePrinter
{
    public void CreateAndPrintTable(List<string> moves)
    {
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
        PrintTable(helpTable, moves.Count());
    }

    private void PrintTable(string[,] helpTable, int n)
    {
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                Console.Write(helpTable[i,j] + ' ');
            }
            Console.WriteLine("");
        }
    }
}