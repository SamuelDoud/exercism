using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Meetup
{
    private int _month;
    private int _year;
    Schedule meetupDates;
    public Meetup(int month, int year)
    {
        this._month = month;
        this._year = year;
         meetupDates = new Schedule(_month, _year); //Schedule holds the information on the calendar
    }
    public DateTime Day(DayOfWeek dayOfWeek, int scheduleCode)
    {
        return meetupDates.GetDate(dayOfWeek, scheduleCode);
    }
}

class Schedule
{
    //static variables for the Schedule class
    public static int First = 0;
    public static int Second = First + 1;
    public static int Third = Second + 1;
    public static int Fourth = Third + 1;
    public static int Last = Fourth + 1;
    public static int Teenth = Last + 1;
    private int _month;
    private int _year;
    private int _daysInMonth;
    DateTime[] monthOnCalendar;
    public Schedule(int month, int year)
    {
        this._year = year;
        this._month = month;
        SetDaysInMonth();
        monthOnCalendar = new DateTime[_daysInMonth];
        GenerateDates();
        
    }
    public void GenerateDates()
    {
        for (int i = 1; i <= _daysInMonth; i++) //go through all the days in a month
        {
            monthOnCalendar[i-1] = new DateTime(_year, _month, i); //create a DateTime entry for that day of the month
        }
    }
    public DateTime GetDate(DayOfWeek dayOfWeek, int occurance)
    {
        if (occurance != Teenth) //teenth is a special case
        {
            for (int i = 1; i <= 7; i++) //go through eah day of the week's first occurance in a month
            {
                if (monthOnCalendar[i - 1].DayOfWeek == dayOfWeek) //pass this test when we have the right day of the week
                {
                    if (i + (occurance) * 7 > _daysInMonth) //overflow check (useful on "Last" case)
                    {
                        occurance = Fourth;//the fourth is sometimes the last day of the week in a month  
                    }
                    return monthOnCalendar[i + (occurance) * 7 - 1]; //return the day of the week by adding a multiple of 7 to the date
                }
            }
        }
        return GetTeenth(dayOfWeek);//teenth case
    }
    private DateTime GetTeenth(DayOfWeek dayOfWeek)
    {
        for (int i = 12; i < 19; i++)//go through every teenth date on the calendar
        {
            if (monthOnCalendar[i].DayOfWeek == dayOfWeek) //return when the days of the week initably match
            {
                return monthOnCalendar[i];
            }
        }
        return new DateTime();
    }
    private void SetDaysInMonth()
    {
        _daysInMonth = 31;//start with the base case of 31 days in a month
        if ((_month < 7 && _month % 2 == 0) || (_month > 7 && _month % 2 == 1))//the rules for 30 day months
        {
            _daysInMonth--;//take a day off.. Febuary satisfies this rule
        }
        if (_month == 2) //special case of febuary
        {
            _daysInMonth = 28; //non-leap year is this long
            if (IsLeap(_year)) //check if a leap year
            {
                _daysInMonth++; //if so, add a day
            }
        }
    }
    public bool IsLeap(int year)
    {
        //checks if a given year is a leap year
        return year % 4 == 0 && (year % 100 != 0  || year % 400 == 0);
    }
}

