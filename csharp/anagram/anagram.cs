using System;
using System.Collections.Generic;

class Anagram
{
    private string _orderedText;
    private string _text;
    public Anagram(string text)
    {
        text = text.Trim(); //whitespace does not matter
        text = text.ToLower();
        //arrange the text passed alphabetically and store that 
        _orderedText = OrderAlphabetically(text);
        _text = text;
    }
    public string[] Match(string[] words)
    {
        List<string> matchedWords = new List<string>(); //the list that we will be returning as an array
        // made to be a list because I do not have prior knowledge the number of matched words
        //go through each word in the passed array of words
        foreach(string word in words)
        {
            if (IsAnagram(word))//check if the word is an anagram
            {
                matchedWords.Add(word); //add that word to the results
            }
        }
        return matchedWords.ToArray();
    }
    private bool IsAnagram(string compare)
    {
        compare = compare.Trim(); //whitespace does not matter
        //anagrams have to be the sam number of characters
        if (compare.Length != _text.Length)
        {
            return false;
        }
        //anagrams do not care about case
        compare = compare.ToLower();
        //check if the anagram's already alphabetically ordered text is equal to the sorted word passed
        //it isn't an anagram if the words are the same
        return !_text.Equals(compare) && _orderedText.Equals(OrderAlphabetically(compare));
    }
    public string OrderAlphabetically(string word)
    {
        char[] charsInWord = word.ToCharArray();
        Array.Sort(charsInWord);//order the char array alphabetically
        return new string(charsInWord);//convert it to a strign and return that
    }
}

