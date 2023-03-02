using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClassDemoThreadTask
{
    public class ThreadWorker
    {
        private static bool done = false;    // Static fields are shared between all threads

        protected delegate void PrintingMethodType(String str);

        public ThreadWorker()
        {
        }

        public void Start()
        {
            //StartDelegates();

            //StartThreadTest();

            StartTaskTest();


            //CriticalRegionTest critRegion = new CriticalRegionTest();
            //critRegion.Start();
        }

        private void StartDelegates()
        {
            PrintingMethodType metRef = (s) => { Console.WriteLine("Hello " + s); };

            metRef("Peter");


            metRef += NamedMethod;
            metRef("Henrik");

            metRef -= NamedMethod;
            metRef("Anders");

        }

        public void NamedMethod(String name)
        {
            Console.WriteLine("Hi " + name);
        }

        /*
         *
         * THREADS
         *
         */

        private void StartThreadTest()
        {
            new Thread(Go).Start();
            Go();
        }

        private void Go()
        {
            if (!done) { done = true; Console.WriteLine("Done"); }
        }



        /*
         *
         * TASKS
         *
         */

        private void StartTaskTest()
        {
            Task.Run(() => DoWork("Number One", ConsoleColor.Red));
            Task.Run(() => DoWork("Number Two", ConsoleColor.Green));
        }

        private void DoWork(String name, ConsoleColor colour)
        {
            for (int i = 0; i < 30; i++)
            {
                Console.ForegroundColor = colour;
                Console.WriteLine($"Name {name} no={i}");
            }
        }
    }
}