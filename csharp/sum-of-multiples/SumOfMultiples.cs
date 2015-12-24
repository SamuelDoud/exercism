using System;
using System.Collections.Generic;
using System.Linq;


class SumOfMultiples
{
    public List<int> _multiples { get; private set; }
    public readonly List<int> defaultMultiples = new List<int>() { 3, 5 };
    public SumOfMultiples()
    {
        _multiples = defaultMultiples; //no argument was passed so the default multiples are used
    }
    public SumOfMultiples(List<int> multiples)
    {
        _multiples = multiples; //use the passed mutliples
    }
    public int To(int limit)
    {
        Dictionary<int, int> multiplesUnderLimit = new Dictionary<int, int>();//use a keyed dictionary to catch multiples and deal with collisions
        foreach (int multiple in _multiples) //go through each of the multiples in the object
        {
            for (int incrementedMultiple = multiple; incrementedMultiple < limit; incrementedMultiple += multiple)//increment until we reach the passed limit
            {
                if (!multiplesUnderLimit.ContainsKey(incrementedMultiple)) //checks for collisions.. i.e. for 3 and 2 with a limit of 10, 6 will be considered twice
                {
                    multiplesUnderLimit.Add(incrementedMultiple, 0); //adds the key to the dictionary
                }
            }
        }
        return multiplesUnderLimit.Keys.ToList().Sum(); //returns the sum of all the keys
        //possibly more efficient to use a bit array of size limit
        //dictionaries allow for simple summing
    }
    
}
