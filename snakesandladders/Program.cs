using System;


namespace snakesandladders
{
    /// <summary>
    /// This is a client class for executing snakes and ladders
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //initialize the game
            //While No one reached 100
            //do, player =1 0r 2
            //int=roll dice
            //calculate Nextposition
            //examine Game is over
            //If yes annouce the result
            //No, select different player and continue
            Game SAL = new Game();
            Console.WriteLine("Please enter player1 Name:");
            string player1 = Console.ReadLine();
            Console.WriteLine("Please enter player2 Name:");
            string player2 = Console.ReadLine();
            SAL.player1 = new Player(player1, 0);
            SAL.player2 = new Player(player2, 0);
            int i = 1;
            while (!SAL.Isgameover())
            {
                Player p = (i % 2 == 0) ? SAL.player1 : SAL.player2;
           
                SAL.ExecuteStep(p, SAL.RollDice());
                i++;
            }
           string winner= SAL.GetWinner();
            Console.WriteLine($"{winner} has won the match");
            Console.ReadKey();
        
         
        }
    }
}
