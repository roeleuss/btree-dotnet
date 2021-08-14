using System;
using System.Collections.Generic;
using System.Text;

namespace ReeX.Btree.Core
{
    public class BinaryTree : ITree
    {
        private readonly Node root = new Node();

        public void Add(int value)
        {
            root.Add(value);
        }

        public bool Contains(int value)
        {
            return root.Get(value) != null;
        }

        public int Count()
        {
            return root.Count;
        }
    }
}
