using System;
using System.Collections.Generic;
using System.Linq;


namespace PhoneDirectory
{
    class KeypadDictionary
    {
        public Dictionary<int,List<char>> dictionary { get; set; }

        public KeypadDictionary()
        {
            int charAsciiBegin = 65;
            var exception = new int[] { 7, 9 };
            dictionary = new Dictionary<int, List<char>>();
            dictionary.Add(0, new List<char>() {' '});
            dictionary.Add(1, new List<char>() {'.'});

            for (int i=2;i<10;i++)
            {
                if(exception.Contains(i))
                    dictionary.Add(i, new List<char>() { (char)charAsciiBegin++, (char)charAsciiBegin++, (char)charAsciiBegin++, (char)charAsciiBegin++ });
                else
                    dictionary.Add(i, new List<char>() { (char)charAsciiBegin++, (char)charAsciiBegin++, (char)charAsciiBegin++ });
            }
        }
        public string StringGenerator(string inputNumber)
        {
            string outputNameString = "";
            int inputNumberSplit;
            for (int i = 0; i < inputNumber.Length;i++ )
            {
                inputNumberSplit = int.Parse(inputNumber.Substring(i,1));
                outputNameString += "[" + string.Join<char>("|", dictionary[inputNumberSplit]) + "]";
            }
            return outputNameString;
        }
    }
}
