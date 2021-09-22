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

        /// <summary>
        /// Iterates through the commandsArray - calling upon the required function.
        /// </summary>
        public void parseCommands()
        {
            fillGrid();

            for (int i = 0; i < commandsArray.Length; i++)
            {
                string command = commandsArray[i].ToLower();
                if (command.EndsWith("m"))
                {
                    move(command);
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

        /// <summary>
        /// Handles the movement of the Mars Rover.
        /// </summary>
        /// <param name="distanceString"></param>
        public void move(string distanceString)
        {
            //Removing the 'm' from the movement command.
            distanceString = distanceString.Substring(0, distanceString.Length - 1);
            //Parsing to an integer.
            int distance = Int32.Parse(distanceString);

            #region Movement
            //Checks the direction the rover is facing.
            if (direction == "North")
            {
                //Check to ensure the boundary is not exceeded.
                if ((yPosition - distance > -1))
                {
                    //Moves the rover to a new position.
                    yPosition -= distance;
                    Console.WriteLine("Moving " + distance + "m North.");
                }
            }
            else if (direction == "East")
            {
                if ((xPosition + distance < 101))
                {
                    xPosition += distance;
                    Console.WriteLine("Moving " + distance + "m East.");
                }
            }
            else if (direction == "South")
            {
                if ((yPosition + distance < 101))
                {
                    yPosition += distance;
                    Console.WriteLine("Moving " + distance + "m South.");
                }
            }
            else if (direction == "West")
            {
                if ((xPosition - distance > -1))
                {
                    xPosition -= distance;
                    Console.WriteLine("Moving " + distance + "m West.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Direction.");
            }

            Console.WriteLine("Rover Position: [" + xPosition + ", " + yPosition + "].");
            #endregion
        }
    }
}
