using System;

internal class Bob
{
    //response strings
    static string defaultResponse = "Whatever.";
    static string questionResponse = "Sure.";
    static string exclamatoryResponse = "Whoa, chill out!";
    static string silentResponse = "Fine. Be that way!";

    internal static string Hey(string text)
    {
        text = text.Trim(); //trim the whitespace at the end of this string
        if (IsSilent(text))
        {
            return silentResponse;
        }
        if (IsExclamatory(text))
        {//Exclamations are the first check
            return exclamatoryResponse;
        }
        if (IsQuestion(text))
        {//exclamations supercede questions in Bob's logic
            return questionResponse;
        }
        return defaultResponse; //no other responses were valid
    }
    internal static bool IsQuestion(string text)
    {
        //trim the text of the silence at the end, if there is any
        return text.EndsWith("?"); //Questions in English end with a question mark
    }
    internal static bool IsSilent(string text)
    {
        return text.Length == 0;
        //if nothing is said then the string has no length
    }
    internal static bool IsExclamatory(string text)
    {
        return HasLetters(text) && text.Equals(text.ToUpper());
        //if the text is equal to an upper case copy of itself, it is defined as yelling
    }
    internal static bool HasLetters(string text)
    {
        //go thru each char in the text (in lower case) and see if any character is a letter
        foreach (int ASCIIValue in text.ToLower())
        {
            if (ASCIIValue >= 97 && ASCIIValue <= 122)
            {
                return true;
            }
        }
        return false;
    }
}

