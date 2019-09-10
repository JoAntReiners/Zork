using System;

namespace Zork
{
    enum Commands
    {
        QUIT,
        LOOK,
        NORTH,
        SOUTH,
        EAST,
        WEST,
        UNKNOWN
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            Commands command = Commands.UNKNOWN;
            
            while(command != Commands.QUIT)
            {
                string outputString = "";

                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                switch (command)
                {
                    case Commands.NORTH:
                        outputString = "You moved NORTH";
                        break;
                    case Commands.SOUTH:
                        outputString = "You moved SOUTH";
                        break;
                    case Commands.EAST:
                        outputString = "You moved EAST";
                        break;
                    case Commands.WEST:
                        outputString = "You moved WEST";
                        break;
                    case Commands.LOOK:
                        outputString = "A rubber mat saying 'Welcome to Zork!' lies by the door.";
                        break;
                    case Commands.QUIT:
                        outputString = "Thank you for playing!";
                        break;
                    case Commands.UNKNOWN:
                        outputString = "Unknown Command.";
                        break;
                    default:
                        outputString = "Unknown Command.";
                        break;
                }

                Console.WriteLine(outputString);
            }
                
        }

        private static Commands ToCommand(string commandString) => (Enum.TryParse(commandString, true, out Commands result)) ? result : Commands.UNKNOWN;

    }
}
