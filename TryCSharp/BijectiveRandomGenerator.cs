using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TryCSharp
{
    public class BijectiveRandomGenerator
    {
        private const string Alphabets = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string Encode(long number)
        {
            if (number == 0) return Alphabets[0].ToString();
            long alphabetLength = Alphabets.Length;
            string encodedString = string.Empty;

            while (number > 0)
            {
                long result;
                number = Math.DivRem(number, alphabetLength, out result);
                encodedString = Alphabets[(int)result] + encodedString;
            }

            return encodedString;
        }

        public static long Decode(string value)
        {
            int alphabetLength = Alphabets.Length;
            int indexer = value.Length - 1;
            long result = 0;

            for (int i = 0; i < value.Length; i++)
            {
                result += (long)(Alphabets.IndexOf(value[i]) * Math.Pow((double)alphabetLength, (double)indexer));
                indexer--;
            }

            return result;
        }
    }
}