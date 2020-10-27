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
        /// 

        // Bài này em không hiểu đề cho lắm
        static void Main(string[] args)
        {
            Console.WriteLine(Convert<int>("", 0));
            Console.ReadKey();
        }
        static T Convert<T>(object a, T idefault) where T : struct
        {
            if (String.IsNullOrEmpty(a.ToString()))
            {
                return idefault;
            }
            else
            {
                return (T)System.Convert.ChangeType(a, typeof(T));
            }
        } 
    }
}
