using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAITAP3
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine("Dog waitting...");
            Console.WriteLine("Cat waitting...");
            Console.WriteLine("Chicken waitting...");
            Console.WriteLine("Start running.......................................");
            Thread dogRun = new Thread(DogRun);
            Thread catRun = new Thread(CatRun);
            Thread chickenRun = new Thread(ChickenRun);
            dogRun.Start();
            catRun.Start();
            chickenRun.Start();
            watch.Stop();
            Thread.CurrentThread.Join();
            Console.WriteLine(watch.ElapsedMilliseconds);
            Console.ReadKey();
        }
        static void DogRun()
        {
            Console.WriteLine("Dog waitting...");
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("Dog running...");
            }
            Console.WriteLine("\t\t\tDog completed");
        }
        static void CatRun()
        {
            Console.WriteLine("Cat waitting...");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Cat running...");
            }
            Console.WriteLine("\t\t\tCat completed");
        }
        static void ChickenRun()
        {
            Console.WriteLine("Chicken waitting...");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Chicken running...");
            }
            Console.WriteLine("\t\t\tChicken completed");
        }
    }
}
