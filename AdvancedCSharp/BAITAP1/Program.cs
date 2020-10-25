using System;

namespace BAITAP1
{
    class Program
    {
        /// <summary>
        /// Convert the value of the parameter passed
        /// Does not depend on the data type of the parameter passed
        /// The transmitted data type limit is Struct
        /// </summary>

        /// <param name="value"></param>
        /// <param name="idefault"></param

        /// <returns>
        /// The value of the parameter passed according to its data type
        /// If the parameter passed has no value, the default is idefault
        /// </returns>
        static void Main(string[] args)
        {
            Convert<int>(null);
            Console.ReadKey();
        }
        static void Convert<T>(T? a) where T : struct 
        {
            if (a == null)
                Console.WriteLine("idefault");
            else
                Console.WriteLine("Value: " + a);
        } // 2

    }
}
