using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManageThreads
{
    class Program
    {
        static double[] data = new double[10];

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Thread[] threads = new Thread[count];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(Generator);
                threads[i].Start(new object[] { i, count });
            }

            foreach (var t in threads)
            {
                t.Join();
            }

            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine(data[i]);
            }
        }

        static void Generator(object state)
        {
            object[] args = (object[])state;
            int index = (int)args[0];
            int count = (int)args[1];

            int start = data.Length / count * index;
            int end = start + data.Length / count;

            if (index == -1)
            {
                end = data.Length; 
            }

            Random r = new Random();
            for (int i = start; i < end; i++)
            {
                data[i] = r.NextDouble();
                Thread.Sleep(10);
            }


        }
    }
}
