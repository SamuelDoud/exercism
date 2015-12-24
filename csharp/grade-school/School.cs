using System;
using System.Collections.Generic;

class School
{
    public Dictionary<int, SortedSet<string>> Roster
    {
        get;
        private set;
    }
    public School()
    {
        Roster = new Dictionary<int, SortedSet<string>>();
    }
    public void Add(string name, int grade)
    {
        if (Roster.ContainsKey(grade))
        {
            Roster[grade].Add(name); //add the name to the set after verifying that there are already students in this grade
        }
        else
        {
            SortedSet<string> newGradeNames = new SortedSet<string>(); //create a new sortedset
            newGradeNames.Add(name); //add the name passed to that sorted set
            Roster.Add(grade, newGradeNames); //add the sorted set to the Dictionary with the grade
        }
    }
    public SortedSet<string> Grade(int grade)
    {
        if (Roster.ContainsKey(grade))
        {
            return Roster[grade];//return the grade since it exists
        }
        return new SortedSet<string>(); //since there are no students in this grade, return an empty set
    }

}
