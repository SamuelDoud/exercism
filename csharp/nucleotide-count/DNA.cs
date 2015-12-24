using System;
using System.Collections.Generic;
using System.Linq;

class DNA
{
    private string _strand; //the string which holds the chemicals of the DNA
    public Dictionary<char, int> NucleotideCounts { get; private set; }//where the counts will come from
    public readonly char[] DNAChems = new char[] { 'A', 'T', 'C', 'G' }; //the chemicals found in a strand of DNA
    public DNA(string strand)
    {
        _strand = strand;
        NucleotideCounts = new Dictionary<char, int>();
        generateCounts();
    }
    private void generateCounts()
    {
        //this function takes the strand of DNA and counts all the instances of a certain chemical in the strand
        foreach (char chemical in DNAChems) 
        {
            try
            {
                NucleotideCounts.Add(chemical, _strand.Count(x => x == chemical));//set all the chemicals to a count determined by the LINQ count method
            }
            catch
            {
                throw new InvalidNucleotideException("The chemical: " + chemical + " is invalid."); //a chemical is not valid if this code is reached
            }
        }
    }
    public int Count(char chemical)
    {
        try
        {
            return NucleotideCounts[chemical]; //if the key exists, this code will be reached
            //returns the number of nucleotides of the chemical
        }
        catch
        {
            throw new InvalidNucleotideException("The chemical: " + chemical + " is invalid."); //the chemical is not valid if this code is reached
        }
    }
}
public class InvalidNucleotideException : Exception
{
    public InvalidNucleotideException(String message)
    {
        Console.WriteLine(message);
    }
}
