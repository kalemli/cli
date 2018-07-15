using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCli
{
    class Program
    {
        private static string Prefix => "   $: ";
        private static List<string> CommandHistory = new List<string>();
        private static string[] Commands = new string[]
        {
            "commit",
            "branch",
            "revert",
            "quit"
        };

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();

            string command = "";
            while (true)
            {
                Console.Clear();
                CommandHistory.ForEach(cmd => WriteCommand(cmd, true));
                WriteCommand(command);
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Backspace:
                        command = command.Substring(0, Math.Max(0, command.Length - 1));
                        break;
                    case ConsoleKey.Enter:
                        ExecuteCommand(command);
                        command = "";
                        break;
                    case ConsoleKey.Tab:
                        command = Commands.FirstOrDefault(x => x.StartsWith(command)) ?? command;
                        break;
                    default:
                        command += key.KeyChar;
                        break;
                }
            }
        }

        private static void WriteCommand(string command, bool newLine = false)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Prefix);

            Console.ForegroundColor = ConsoleColor.Yellow;
            if (newLine)
                Console.WriteLine(command);
            else
                Console.Write(command);
        }

        private static void ExecuteCommand(string command)
        {
            switch (command)
            {
                case "quit":
                    Console.Clear();
                    Environment.Exit(0);
                    break;
            }
            CommandHistory.Add(command);
        }
    }
}
