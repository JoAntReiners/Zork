using System;
using Zork;

string[] responces = new string[]
{
    "Good day.",
    "Nice weather we've been having lately.",
    "Nice to see you."
};

var command = new Command("HELLO", new string[] { "HELLO", "HI", "HOWDY" }, (game, commandContext) =>
 {
     string selectedResponce = responces[Game.Random.Next(responces.Length)];
     Console.WriteLine(selectedResponce);
 });

Game.Instance.CommandManager.AddCommand(command);
