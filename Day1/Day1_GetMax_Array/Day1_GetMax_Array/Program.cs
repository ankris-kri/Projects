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
            int _length,_number,_preference,_count=0;
            bool _temp=true;
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
            
            while(_temp)
            {
                Console.WriteLine("\nEnter Your preference:\n1)GetArray\n2)Max_Array\n3)Min_Array\n4)Sort_Array\n5)Exit");
                if(!(int.TryParse(Console.ReadLine(),out _preference)))
                {
                    Console.WriteLine("TRY AGAIN");
                    continue;
                }
                switch(_preference)
                {
                    case 1:
                        Console.Write("Array elements are:");
                        foreach(int local in demo.GetArray())
                        {
                            Console.Write("\t{0}",local.ToString());
                        }
                        Console.Write("\n");
                        break;
                    case 2:
                        Console.WriteLine("The Maximum number is {0}",demo.GetMax());   //method to find the maximum number in an array
                        break;
                    case 3:
                        Console.WriteLine("The Minimum number is {0}",demo.GetMin());  //minimum number of the array
                        break;
                    case 4:
                        Console.Write("Sorted Array elements are:");
                        foreach(int local in demo.SortedArray())
                        {
                            Console.Write("\t{0}",local.ToString());
                        }
                        Console.Write("\n");
                        break;
                        
                    case 5:
                        _temp = false;
                        Console.WriteLine("Thank you");
                        break;
                    default:
                        Console.WriteLine("Invalid Input.Try again");
                        break;
                   
                }
                
            }
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
        public int GetMin()
        {
            int _min= int.MaxValue ;
            foreach (int temp in _intArray)
            {
                if (temp < _min)
                    _min = temp;
            }
            return _min;
        }
        public int[] SortedArray()
        {
            int[] _sortArray = new int[_intArray.Length];
            _intArray.CopyTo(_sortArray, 0);
            for (int _i = 0; _i < _sortArray.Length; _i++)
            {
                for (int _j = _i + 1; _j <_sortArray.Length; _j++)
                {
                    if (_sortArray[_i] > _sortArray[_j])
                    {
                        int _temp = _sortArray[_i];

                        _sortArray[_i] =  _sortArray[_j];

                       _sortArray[_j] = _temp;
                    }
                }
            }
            return _sortArray;

        }
        public int[] GetArray()
        {
            return _intArray;
        }

    }
}







