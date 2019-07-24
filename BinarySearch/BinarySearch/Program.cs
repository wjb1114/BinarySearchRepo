using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree(0);
            for (int i = 1; i <= 10000; i++)
            {
                tree.Add(i);
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
