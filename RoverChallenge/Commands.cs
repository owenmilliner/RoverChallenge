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
        public int xPosition = 0, yPosition = 0;
        string direction = "South";
        public bool gridBoundariesExceeded = false;
        #endregion

        /// <summary>
        /// Iterates through the commandsArray - calling upon the required function.
        /// </summary>
        public void parseCommands()
        {
            //Aesthetic Improvements.
            Console.WriteLine("\nCalculating..."
                + "\nStarting Position: [" + xPosition + ", " + yPosition + "]."
                + "\nStarting Direction: " + direction + "\n");

            //Reset of variable.
            gridBoundariesExceeded = false;

            for (int i = 0; i < commandsArray.Length; i++)
            {
                string command = commandsArray[i].ToLower();
                //If the boundaries are exceeded, break the loop and commit no further commands.
                if (gridBoundariesExceeded == true)
                {
                    break;
                }
                else if (command.EndsWith("m"))
                {
                    move(command);
                }
                else if (command.Equals("left"))
                {
                    turnRover("Left");
                }
                else if (command.Equals("right"))
                {
                    turnRover("Right");
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
                //If the value exceeds that of the assigned grid, change bool value to true.
                else
                {
                    Console.WriteLine("Unauthorised breach of mission grid. Mission aborted.");
                    gridBoundariesExceeded = true;
                }
            }
            else if (direction == "East")
            {
                if ((xPosition + distance < 101))
                {
                    xPosition += distance;
                    Console.WriteLine("Moving " + distance + "m East.");
                }
                else
                {
                    Console.WriteLine("Unauthorised breach of mission grid. Mission aborted.");
                    gridBoundariesExceeded = true;
                }
            }
            else if (direction == "South")
            {
                if ((yPosition + distance < 101))
                {
                    yPosition += distance;
                    Console.WriteLine("Moving " + distance + "m South.");
                }
                else
                {
                    Console.WriteLine("Unauthorised breach of mission grid. Mission aborted.");
                    gridBoundariesExceeded = true;
                }
            }
            else if (direction == "West")
            {
                if ((xPosition - distance > -1))
                {
                    xPosition -= distance;
                    Console.WriteLine("Moving " + distance + "m West.");
                }
                else
                {
                    Console.WriteLine("Unauthorised breach of mission grid. Mission aborted.");
                    gridBoundariesExceeded = true;
                }
            }
            else
            {
                Console.WriteLine("Invalid Direction.");
            }

            Console.WriteLine("Rover Position: [" + xPosition + ", " + yPosition + "].");
            #endregion
        }

        /// <summary>
        /// Function to turn the rover (change the direction variable).
        /// </summary>
        /// <param name="redirect"></param>
        public void turnRover(string redirect)
        {
            //Checks the current direction, and changes the value based upon the redirection command provided.
            if (direction == "North")
            {
                if (redirect == "Left")
                {
                    direction = "West";
                }
                else if (redirect == "Right")
                {
                    direction = "East";
                }
            }
            else if (direction == "East")
            {
                if (redirect == "Left")
                {
                    direction = "North";
                }
                else if (redirect == "Right")
                {
                    direction = "South";
                }
            }
            else if (direction == "South")
            {
                if (redirect == "Left")
                {
                    direction = "East";
                }
                else if (redirect == "Right")
                {
                    direction = "West";
                }
            }
            else if (direction == "West")
            {
                if (redirect == "Left")
                {
                    direction = "South";
                }
                else if (redirect == "Right")
                {
                    direction = "North";
                }
            }
            else
            {
                Console.WriteLine("Turning Error.");
            }

            Console.WriteLine("Rover turned. Now pointing " + direction + ".");
        }
    }
}
