using System;

namespace Zork
{
    public static class Movement
    {
        public static void NORTH(Game game, CommandContext commandContext) => Move(game, Directions.North);

        public static void SOUTH(Game game, CommandContext commandContext) => Move(game, Directions.South);

        public static void EAST(Game game, CommandContext commandContext) => Move(game, Directions.East);

        public static void WEST(Game game, CommandContext commandContext) => Move(game, Directions.West);

        public static void Move(Game game, Directions direction)
        {
            bool playerMoved = game.Player.Move(direction);
            if(playerMoved == false)
            {
                Console.WriteLine("The way is shut!");
            }
        }
    }
}
