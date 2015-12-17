using System;
using System.Collections.Generic;

namespace snakesandladders
{
   public class Game
    {
        public Player player1;
        public Player player2;
        public Dictionary<int, int> StartAndEndOfSnakesAndLadders = new Dictionary<int, int>() { { 12, 25 }, { 35, 10 }, {27,98 }, { 83,91}, { 95,5}, { 85,55} };
        //Create a DS for snakes and ladders
        // game has execute step method
        //Assumptions are,
        //1.Snakes and ladders positions are fixed
        //2.Only 2 players
        //3. Traditional snakes and ladders with 100 being the maximum position

        public int RollDice()
        {
            Random rnd = new Random();
            int dice = rnd.Next(1, 7);//gives a number between 1 and 6
            return dice;
        }
        public void ExecuteStep(Player p,int diceValue)
        {
            string TypeOfMove;
             var NextPosition = GetNextPosition(p, diceValue); // get acceptable next position. check for max
            getConsoleLog(p.Name, diceValue);
            NextPosition = CheckforSnakesAndLadders(NextPosition,out TypeOfMove);
            p.CurrentPosition = NextPosition;
            getConsoleLog(p.Name, p.CurrentPosition, TypeOfMove);
           
          
        }

        private void getConsoleLog(string name, int currentPosition,string type="Dice")
        {
            if (type == "Snake")
            {
                Console.WriteLine($"Player {name} got a snake and is moved to {currentPosition} ");
            }
            else if (type == "Ladder")
            {

                Console.WriteLine($"Player {name} got a Ladder and is moved to {currentPosition} ");
            }
            else if (type == "Move")
            {

                Console.WriteLine($"Player {name} is moved to {currentPosition} ");
            }
            else
            {
                Console.WriteLine($"Player {name} is rolled dice and got {currentPosition} ");
            }
       
        }

        private int CheckforSnakesAndLadders(int Position,out string snakeorLadder)
        {
            int endPosition;
            if (StartAndEndOfSnakesAndLadders.ContainsKey(Position))
            {
                //if there is a snakle or ladder at the given position
                 endPosition = StartAndEndOfSnakesAndLadders[Position];
                if (endPosition > Position)
                {
                    snakeorLadder = "Ladder";

                }
                else
                    snakeorLadder = "Snake";
                return endPosition;
            }
            else
            {
                 // if no snake or ladder, endposition is same as given position
                snakeorLadder = "Move";
                endPosition = Position;
            }

            return endPosition;
        }

        public bool Isgameover()
        {
            if (player1.CurrentPosition == 100 || player2.CurrentPosition == 100)
                return true;
            
            return false;

        }
        public string GetWinner()
        {
            if (player1.CurrentPosition == 100)
                return player1.Name;
            else
                return player2.Name;
        }
        /// <summary>
        /// Sets the next position value. If the dice value places position >100, that turn is not considered.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="DiceValue"></param>
        /// <returns></returns>
        private int GetNextPosition(Player p,int DiceValue)
        {
            int nextPosition= (p.CurrentPosition + DiceValue <= 100) ? ( p.CurrentPosition + DiceValue): p.CurrentPosition;
            return nextPosition;
        }

    }
}
