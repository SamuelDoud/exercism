using System;
using System.Collections.Generic;
using System.Linq;


class SumOfMultiples
{
    public List<int> _multiples { get; private set; }
    public readonly List<int> defaultMultiples = new List<int>() { 3, 5 };
    public SumOfMultiples()
    {
        _multiples = defaultMultiples;
    }
    public SumOfMultiples(List<int> multiples)
    {
        _multiples = multiples;
    }
    public int To(int limit)
    {
        Dictionary<int, int> multiplesUnderLimit = new Dictionary<int, int>();
        foreach (int multiple in _multiples)
        {
            for (int incrementedMultiple = multiple; incrementedMultiple < limit; incrementedMultiple += multiple)
            {
                if (!multiplesUnderLimit.ContainsKey(incrementedMultiple))
                {
                    multiplesUnderLimit.Add(incrementedMultiple, 0);
                }
            }
        }
        return multiplesUnderLimit.Keys.ToList().Sum();
    }
    
}
