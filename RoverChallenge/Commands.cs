using System;
using System.Collections.Generic;
using System.Text;

namespace RoverChallenge
{
    class Commands
    {
        #region Variables
        //Variables to be used throughout command execution.
        public string[] commandsArray = new string[5];
        public int[,] grid = new int[100, 100];
        public int xPosition = 0, yPosition = 0;
        string direction = "South";
        #endregion

        /// <summary>
        /// Filling the contents of the mission grid.
        /// </summary>
        public void fillGrid()
        {
            int counter = 1;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = counter;
                    counter++;
                }
            }
        }

        public void parseCommands()
        {
            fillGrid();

            for (int i = 0; i < commandsArray.Length; i++)
            {
                string command = commandsArray[i].ToLower();
                if (command.EndsWith("m"))
                {
                    Console.WriteLine("Moving");    
                }
                else if (command.Equals("left"))
                {
                    Console.WriteLine("Moving Left");
                }
                else if (command.Equals("right"))
                {
                    Console.WriteLine("Moving Right");
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }
            }
        }
    }
}
