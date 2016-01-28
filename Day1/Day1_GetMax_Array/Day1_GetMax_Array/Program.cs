using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_GetMax_Array
{


    class Program
    {
        static void Main(string[] args)
        {
            int _length,_number,_count=0;
            Console.WriteLine("Enter the length of the array");
            while (!(int.TryParse(Console.ReadLine(), out _length)))
            {
                Console.WriteLine("please enter a valid input");
                continue;
            }
            IntArray demo = new IntArray(_length);
            Console.WriteLine("please enter {0} input values", _length);
    
            while (_count!=_length)
            {   
                if((!(int.TryParse(Console.ReadLine(), out _number))))
                {
                Console.WriteLine("please enter a valid input");
                continue;
                }
                demo.AddNumber(_count, _number);    //method to add values into an array
                ++_count;
            }
           
            

            Console.WriteLine("The Maximum numbers is {0}",demo.GetMax());   //method to find the maximum number in an array
            Console.ReadLine();
        }

    }
    class IntArray
    {

        int[] _intArray;
        public IntArray(int inputLenth)
        {
            _intArray = new int[inputLenth];
        }


        public void AddNumber(int index, int value)
        {
            _intArray[index] = value;
        }


        public int GetMax()
        {
            int _max = 0;
            foreach (int temp in _intArray)
            {
                if (temp > _max)
                    _max = temp;
            }
            return _max;
        }

    }
}







