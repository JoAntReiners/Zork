using System;

namespace Zork
{

    class Program
    {
        private static string[] Rooms = {"Forest", "West of House", "Behind House", "Clearing", "Canyon View" };
        private static int currentPos = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            Commands command = Commands.UNKNOWN;
            
            while(command != Commands.QUIT)
            {
                string outputString = "";
                Console.WriteLine(Rooms[currentPos]);
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                switch (command)
                {
                    case Commands.NORTH:                      
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        if (Move(command))
                        {
                            outputString = $"You moved {command}.";
                        }
                        else
                        {
                            outputString = "The way is shut!";
                        }
                        break;
                    case Commands.LOOK:
                        outputString = "This is an open field west of a white house, with a boarded front door.\nA rubber mat saying 'Welcome to Zork!' lies by the door.";
                        break;
                    case Commands.QUIT:
                        outputString = "Thank you for playing!";
                        break;
                    case Commands.UNKNOWN:
                    default:
                        outputString = "Unknown Command.";
                        break;
                }

                Console.WriteLine(outputString);
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

            bool moveSuccessful;

            switch(command)
            {
                
                case Commands.EAST when currentPos < Rooms.Length - 1:
                    moveSuccessful = true;
                    currentPos++;
                    break;
                case Commands.WEST when currentPos > 0:
                    moveSuccessful = true;
                    currentPos--;
                    break;
                default:
                    moveSuccessful = false;
                    break;
            }
            return moveSuccessful;
        }

    }
}
