using System;

namespace snakesandladders
{
   public class Player
    {
       
        public string Name { get; set; }
        public int CurrentPosition { get; set; }
       public  Player(string name, int position)
        {
            Name = name;
            CurrentPosition = position;
        }
    }
}
