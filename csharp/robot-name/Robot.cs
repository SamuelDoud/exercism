using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Robot
{
    public static List<string> UsedRobotNames = new List<string>();
    public string Name{get; private set;}
    public Robot()
    {
        Name = GenrateRandomRobotName();
    }
    public static string GenrateRandomRobotName()
    {
        int i;
        Random generator = new Random(DateTime.Now.Millisecond);//set the seed to the the milliseconds of the day.
        char[] strCharArr = new char[5];//how long the name is to be
        for (i = 0; i < 2; i++)//the first two characters are random alphabetic characters
        {
            strCharArr[i] = (char)(generator.Next(26) + 65);//there are 26 characters in the alphabet with the first ascii being at 65
        }
        for (; i < 5; i++ )
        {
            strCharArr[i] = (char)(generator.Next(10) + 48);//there are 106 characters in the digits with the first ascii being at 48
        }
        string newName = new string(strCharArr);
        if (UsedRobotNames.Contains(newName))
        {
            newName = GenrateRandomRobotName();//the name is already in the list, recur to generate a new name
        }
        UsedRobotNames.Add(newName); //add the name to the list
        return newName;//return the name
    }
    public void Reset()
    {
        Name = GenrateRandomRobotName();
    }
}

