using ReeX.Btree.Core;
using System;

namespace ReeX.BTree.App
{
    class Program
    {
        const int DEFAULT_LOOP = 100;

        static void Main(string[] args)
        {
            if (args.Length == 0 || !int.TryParse(args[0], out int loop)) loop = DEFAULT_LOOP;
            Console.WriteLine($"Loops: {loop}");

            ITree tree = new BinaryTree();
            Random random = new Random();

            Populate(loop, tree, random);
            Count(tree);
            Locate(loop, tree, random);
        }

        private static void Populate(int loop, ITree tree, Random random)
        {
            DateTime init = DateTime.Now;
            for (int i = 0; i < loop; i++)
            {
                tree.Add(random.Next(loop));
            }
            DateTime end = DateTime.Now;
            Console.WriteLine($"POPULATE :: Elapsed Time: {loop,12} nodes at {(end - init).TotalMilliseconds,10:F0} milliseconds");
        }

        private static void Count(ITree tree)
        {
            DateTime init = DateTime.Now;

            var count = tree.Count();
            
            DateTime end = DateTime.Now;
            Console.WriteLine($"COUNT    :: Elapsed Time: {count,12} nodes at {(end - init).TotalMilliseconds,10:F0} milliseconds");
        }

        private static void Locate(int loop, ITree tree, Random random)
        {
            DateTime init = DateTime.Now;
            int locates = 0;
            for (int i = 0; i < loop; i++)
            {
                if (tree.Contains(random.Next(loop)))
                    locates++;
            }
            DateTime end = DateTime.Now;
            Console.WriteLine($"LOCATE   :: Elapsed Time: {locates,12} nodes at {(end - init).TotalMilliseconds,10:F0} milliseconds");
        }
    }
}
