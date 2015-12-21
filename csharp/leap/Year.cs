using System;

class Year
{
    static void Main()
    {

    }
    /// <summary>
    /// is the passed year a leap year
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    static Year()
    {
        
    }
    public static bool IsLeap(int year)
    {

        //if the year is divisible by 400 it is
        //return as such
        if (year % 400 == 0)
        {
            return true;
        }
        //if the year is divisible by 100, it is not a leap year
        if (year % 100 == 0)
        {
            return false;
        }
        //if we get here, check if the year is divisible by 4
        return year % 4 == 0;
    }
}

