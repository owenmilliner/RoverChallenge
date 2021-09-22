using System;
using System.Collections.Generic;
using System.Text;

namespace RoverChallenge
{
    class Commands
    {
        public string[] commandsArray = new string[5];
        public int[,] grid = new int[100, 100];
        public int xPosition = 0, yPosition = 0;
        string direction = "South";
    }
}
