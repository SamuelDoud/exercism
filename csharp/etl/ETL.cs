using System.Collections.Generic;

class ETL
{
    internal static Dictionary<string, int> Transform(Dictionary<int, IList<string>> oldDict)
    {
        Dictionary<string, int> newDict = new Dictionary<string, int>();
        //loop thru every key
        foreach (KeyValuePair<int, IList<string>> keyPair in oldDict)
        {
            //loop thru every string in the keyPair
            foreach(string letter in keyPair.Value)
            {
                //add a new entry to the dictionary in the new format
                newDict.Add(letter.ToLower(), keyPair.Key);
            }
        }
        return newDict;
    }
}