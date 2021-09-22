using System;

namespace RoverChallenge
{
    class Program
    {
        /*
         * Can you design an application to control the movements of NASA’s next Mars rover?
         * 
         * Instructions:
         * 1.   You have been told that your exploration area on Mars is a 100 metres x 100 metres square. 
         * 2.   The area has been divided into a 100 x 100 grid of numbered squares. 
         * 3.   The squares are numbered from 1 through to 10,000.
         * 4.   The rover starts its journey located in square number 1, it is facing south and can either turn left, 
         *      right or move forward a given number of metres. The rover can take a maximum of 5 commands at any time. 
         * 5.   After each set of commands, the rover reports back its current position and the direction that it is facing. 
         * 
         * For example, here is a set of 5 commands:
         *      50m
         *      Left
         *  	23m
         *  	Left
         *  	4m
         *  	
         * The above set of commands would cause the rover to report back position 4,624 north.
         * The next set of commands would then continue from the square where the rover finished. 
         * 
         * Please note that the rover cannot venture outside of the 100 x 100 area. 
         * If the rover is instructed to cross the perimeter of the exploration area, 
         * it will halt and refuse to execute any additional queued commands
        */
        static void Main(string[] args)
        {
            Commands mission = new Commands();

            //Allows the entering of additional commands, after the initial 5 have been entered.
            bool active = true;
            //Welcome message to the program.
            Console.WriteLine("Welcome to NASA's Mars Rover."
                + "\nPlease a maximum of five commands to be sent to the Mars Rover."
                + "\nAlternatively, enter 'default' for a mission template.");

            while (active == true)
            {
                //Aesthetic improvements.
                Console.WriteLine("\nAwaiting input...");

                //Read the input of the user.
                string userCommand = Console.ReadLine().ToLower();
                //If default commands are to be used.
                if (userCommand == "default")
                {
                    //Template commands to be exectued.
                    mission.commandsArray[0] = "50m";
                    mission.commandsArray[1] = "Left";
                    mission.commandsArray[2] = "23m";
                    mission.commandsArray[3] = "Left";
                    mission.commandsArray[4] = "4m";
                    Console.WriteLine("\nLoading mission template..." +
                        "\n" + mission.commandsArray[0] +
                        "\n" + mission.commandsArray[1] +
                        "\n" + mission.commandsArray[2] +
                        "\n" + mission.commandsArray[3] +
                        "\n" + mission.commandsArray[4]);
                }
                //If custom commands are to be used.
                else
                {
                    //Update first command value.
                    mission.commandsArray[0] = userCommand;
                    //For the remaining 4 commands.
                    for (int i = 1; i < mission.commandsArray.Length; i++)
                    {
                        //Print the submitted command, and the remaining count to submit.
                        Console.WriteLine(userCommand + " submitted. You have " + (mission.commandsArray.Length - i) + " commands remaining.");
                        //Update userCommand variable, and assign it to the next value in the array.
                        userCommand = Console.ReadLine().ToLower();
                        mission.commandsArray[i] = userCommand;
                    }
                }

                mission.parseCommands();

                //Checks whether the user would like to continue or not.
                Console.WriteLine("\nAll commands executed. Would you like to continue? Enter 'Y' or 'N'.");
                userCommand = Console.ReadLine().ToUpper();
                if (userCommand == "N")
                {
                    active = false;
                }
            }
        }
    }
}
