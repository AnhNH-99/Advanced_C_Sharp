using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAITAP3
{
    /*class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dog waitting...");
            Console.WriteLine("Cat waitting...");
            Console.WriteLine("Chicken waitting...");
            Console.WriteLine("Start running.......................................");
            List<Animal> listAnimal = new List<Animal>();
            Animal animal = new Animal();
            Thread dogRun = new Thread(() =>
            {
                Animal dog = new Animal("Dog");
                TimeSpan time = dog.Run();
                dog.InputTime(time);
                listAnimal.Add(dog);
            });
            Thread catRun = new Thread(() =>
            {
                Animal cat = new Animal("Cat");
                TimeSpan time = cat.Run();
                cat.InputTime(time);
                listAnimal.Add(cat);
            });
            Thread chickenRun = new Thread(() =>
            {
                Animal chicken = new Animal("Chicken");
                TimeSpan time = chicken.Run();
                chicken.InputTime(time);
                listAnimal.Add(chicken);
            });
            dogRun.Start();
            catRun.Start();
            chickenRun.Start();
            Thread.Sleep(500);
            Summary(listAnimal);
            Console.ReadKey();
        }
        static void Summary(List<Animal> animals)
        {
            int index = 0;
            Console.WriteLine("Summary");
            foreach (var item in animals.OrderBy(x => x.time))
            {
                index++;
                Console.WriteLine("{0}.{1}: {2}", index, item.name, item.time);
            }
        }
    }
    class Animal
    {
        public string name { get; set; }
        public TimeSpan time { get; set; }
        public Animal()
        {

        }
        public Animal(string name)
        {
            this.name = name;
        }
        public TimeSpan Run()
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i < 10; i++)
            {
                //Thread.Sleep(500);
                Console.WriteLine($"{this.name} running...");
            }
            Console.WriteLine($"\t\t\t{this.name} completed");
            DateTime end = DateTime.Now;
            TimeSpan ts = (end - start);
            return ts;
        }
        public void InputTime(TimeSpan timeSpan)
        {
            this.time = timeSpan;
        }
    }*/
    class Program
    {
        static DateTime start = DateTime.Now;
        static void Main(string[] args)
        {
            var c1 = Waitting();
            Console.WriteLine("Dog {0}", c1);
            var c2 = Waitting();
            Console.WriteLine("Cat {0}", c2);
            var c3 = Waitting();
            Console.WriteLine("Chicken {0}", c3);

            Thread.Sleep(1000);
            Console.WriteLine("Start running......................................");
            Thread.Sleep(1000);
            start = DateTime.Now;
            var task1 = Running(5, "Dog");
            var task2 = Running(10, "Cat");
            var task3 = Running(15, "Chicken");

            Task.WhenAll(task1, task2, task3);

            //Task.WaitAll(task1, task2, task3);

            if (!string.IsNullOrEmpty(task1.Result))
            {
                Console.CursorLeft = 30;
                Console.WriteLine("Dog completed");
            }

            if (!string.IsNullOrEmpty(task2.Result))
            {
                Console.CursorLeft = 30;
                Console.WriteLine("Cat completed");
            }

            if (!string.IsNullOrEmpty(task3.Result))
            {
                Console.CursorLeft = 30;
                Console.WriteLine("Chicken completed");
            }

            //Console.WriteLine("Dog completed: {0}", task1.Result);

            //Console.WriteLine("Cat completed: {0}", task2.Result);

            //Console.WriteLine("Chicken completed: {0}", task3.Result);

            Thread.Sleep(1000);

            Console.WriteLine("Summary");

            Console.WriteLine("1.Dog: {0}", task1.Result);

            Console.WriteLine("2.Cat: {0}", task2.Result);

            Console.WriteLine("3.Chicken: {0}", task3.Result);

            Console.ReadLine();
        }

        static string Waitting()
        {
            Task.Delay(1000).Wait();
            return "waitting...";
        }

        static async Task<string> Running(int value, string opts)
        {
            for (int a = value; a >= 0; a--)
            {
                Console.WriteLine("{0} running...", opts);
                await Task.Delay(1000);
            }
            return (DateTime.Now - start).ToString();
        }
    }

}
