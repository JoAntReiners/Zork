using System;

namespace Zork
{

    class Program
    {
        private static readonly string[,] Rooms = {
            {"Rocky Trail", "South of House", "Canyon View" },
            {"Forest", "West of House", "Behind House" },
            {"Dense Woods", "North of House", "Clearing" }
        };
        private static (int Row , int Column) Location = (1,1);
        

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            Commands command = Commands.UNKNOWN;
            
            while(command != Commands.QUIT)
            {
                
                Console.WriteLine(Rooms[Location.Row , Location.Column]);
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                switch (command)
                {
                    case Commands.NORTH:                      
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        if (!Move(command))
                        {
                            Console.WriteLine("The way is shut!");
                        }
                        break;
                    case Commands.LOOK:
                        Console.WriteLine("This is an open field west of a white house, with a boarded front door.\nA rubber mat saying 'Welcome to Zork!' lies by the door.");
                        break;
                    case Commands.QUIT:
                        Console.WriteLine("Thank you for playing!");
                        break;
                    default:
                        Console.WriteLine("Unknown Command.");
                        break;
                }
            }
                
        }

        private static Commands ToCommand(string commandString) => (Enum.TryParse(commandString, true, out Commands result)) ? result : Commands.UNKNOWN;

        private static bool isCommand(Commands commandString)
        {
            bool isCommand = false;
            switch (commandString)
            {
                case Commands.NORTH:
                case Commands.SOUTH:
                case Commands.EAST:
                case Commands.WEST:
                    isCommand = true;
                    break;
                default:
                    isCommand = false;
                    break;
            }

            return isCommand;
        }

        private static bool Move(Commands command)
        {
            if(isCommand(command))
            {

            }
            else
            {
                throw new Exception("Not a valid input!");
            }

            bool moveSuccessful = true;

            switch(command)
            {
                case Commands.NORTH when Location.Row > 0:
                    Location.Row--;
                    break;
                case Commands.SOUTH when Location.Row < Rooms.GetLength(0) - 1:
                    Location.Row++;
                    break;
                case Commands.EAST when Location.Column < Rooms.GetLength(1) - 1:
                    Location.Column++;
                    break;
                case Commands.WEST when Location.Column > 0:
                    Location.Column--;
                    break;
                default:
                    moveSuccessful = false;
                    break;
            }
            return moveSuccessful;
        }

    }
}
