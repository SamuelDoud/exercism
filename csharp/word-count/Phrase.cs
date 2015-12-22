using System;
using System.Collections.Generic;
class Phrase
{
    internal static Dictionary<string, int> WordCount(string givenWords)
    {
        return ConvertStringArrToDictionaryWithCount(CleanWord(givenWords));        
    }
    // Lower case the word, split the word and remove non words
    internal static string[] CleanWord(string word)
    {
        word = word.ToLower();
        string[] words = SplitingStringByMultipleMeans(word);
        for (int i = 0; i < words.Length; i++ )
        {
            words[i] = RemoveSpecialCharactersFromEnds(words[i]);
        }
        return RemoveNonWords(words);
    }
    internal static string RemoveSpecialCharactersFromEnds(string word)
    {
        if (word.StartsWith("'"))
        {
            word = word.Substring(1, word.Length - 1);
        }
        if (word.EndsWith("'"))
        {
            word = word.Substring(0, word.Length - 1);
        }
        return word;
    }
    // Split the word by the delimiters in the function
    internal static string[] SplitingStringByMultipleMeans(string origWord)
    {
        char[] delimiters = new char[] { ' ', ',', '.', '!', ':', ';', '?' };
        return origWord.Split(delimiters); //cut the strign up by the list above
    }
    // Remove any words from the array that do not contain letters or numbers!
    internal static string[] RemoveNonWords(string[] wordsArr)
    {
        List<string> wordsList = new List<string>();
        foreach (string word in wordsArr)
        {
            if (HasLetters(word))
            {
                wordsList.Add(word);
            }
        }
        return wordsList.ToArray();
    }
    // Checks if the string passed contains letters
    internal static bool HasLetters(string text)
    {
        int baseLetter = 'a';
        int lastLetter = 'z';
        int baseDigit = '0';
        int lastDigit = '9';//ASCII values
        //go thru each char in the text (in lower case) and see if any character is a letter
        foreach (int ASCIIValue in text.ToLower())
        {
            if (ASCIIValue >= baseLetter && ASCIIValue <= lastLetter || ASCIIValue >= baseDigit && ASCIIValue <= lastDigit)
            {//the char is in the range of a lower case letter or number as defined by the ASCII table
                return true;
            }
        }
        return false;
    }
    internal static Dictionary<string, int> ConvertStringArrToDictionaryWithCount(string[] strArr)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        Array.Sort(strArr);
        //now strArr is sorted
        int howManyEqual; //declared outside of the scope of the loop for use beyond the loop
        for (int i = 0; i < strArr.Length; i++)
        {
            for (howManyEqual = 0; howManyEqual + i + 1 < strArr.Length && strArr[i].Equals(strArr[howManyEqual + i + 1]); howManyEqual++)
            {
                //this loop counts how many words are equal to the strArr[i] word
                //do nothing here, just let the howManyEqual variable increment
            }
            i += howManyEqual; //move up the indexing variable to the last instance of this word
            dict.Add(strArr[i], howManyEqual + 1);//add the base word and how many similiar words there are to the array
        }
        return dict;
    }
}
