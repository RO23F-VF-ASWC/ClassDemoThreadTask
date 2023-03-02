using System;
using System.Threading;

namespace ClassDemoThreadTask
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ThreadWorker worker = new ThreadWorker();
            worker.Start();


            Console.ReadLine();
            
        }

    }
}
