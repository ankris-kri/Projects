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
            int _length,_number;
            Console.WriteLine("Enter the length of the array");
            while (!(int.TryParse(Console.ReadLine(), out _length)))
            {
                Console.WriteLine("please enter a valid input");
                continue;
            }
            Array Demo = new Array(_length);
            Console.WriteLine("please enter {0} input values", _length);
            for (int i = 0; i < _length; i++)
            {
             
                while (!(int.TryParse(Console.ReadLine(), out _number)))
                {

                    Console.WriteLine("please enter a valid input");
                    continue;
                }
                Demo.AddNumber(i, _number);    //method to add values into an array
            }

            Console.WriteLine("The Maximum numbers is {0}",Demo.GetMax());   //method to find the maximum number in an array
            Console.ReadLine();
        }

    }
    class Array
    {

        int[] _intArray;
        public Array(int inputLenth)
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







