using System;
using System.Collections.Generic;
class Hamming
{
    internal static int Compute(string key, string compare)
    {
        if (compare.Length != key.Length)
        {//strands should be of equal length
            return -1;
        }
        int hammingDistance = 0;
        char[] compareArr = compare.ToCharArray();
        char[] keyArr = key.ToCharArray();
        for(int i = 0; i < keyArr.Length; i++)
        {//loop thru the entire char array
            if (keyArr[i] != compareArr[i])
            {//compare the chars, if they are not equal the hammingDistance increases by one
                hammingDistance++;
            }
        }
        return hammingDistance;
    }
}
