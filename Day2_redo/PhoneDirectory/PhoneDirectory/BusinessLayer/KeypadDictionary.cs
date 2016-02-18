using System;
using System.Collections.Generic;
using System.Linq;


namespace PhoneDirectory
{
    class KeypadDictionary
    {
        public Dictionary<int,List<char>> dictinary { get; set; }

        public KeypadDictionary()
        {
            int charAsciiBegin = 65;
            var exception = new int[] { 7, 9 };
            dictinary = new Dictionary<int, List<char>>();
            for(int i=2;i<10;i++)
            {
                if(exception.Contains(i))
                    dictinary.Add(i, new List<char>() { (char)charAsciiBegin++, (char)charAsciiBegin++, (char)charAsciiBegin++, (char)charAsciiBegin++ });
                else
                    dictinary.Add(i, new List<char>() { (char)charAsciiBegin++, (char)charAsciiBegin++, (char)charAsciiBegin++ });
            }
        }
        public string StringGenerator(string inputNumber)
        {
            string outputNameString = "";
            int inputNumberSplit;
            for (int i = 0; i < inputNumber.Length;i++ )
            {
                inputNumberSplit = int.Parse(inputNumber.Substring(i,1));
                outputNameString += "[" + string.Join<char>("|", dictinary[inputNumberSplit]) + "]";
            }
            return outputNameString;
        }
    }
}
