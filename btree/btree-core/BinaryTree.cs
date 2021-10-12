using System;
using System.Collections.Generic;
using System.Text;

namespace ReeX.Btree.Core
{
    public class BinaryTree : ITree
    {
        private Node root;

        public void Add(int value)
        {
            if (root == null)
            {
                root = new Node()
                {
                    Side = Node.ROOT,
                    Value = value
                };
            }
            else
            {
                root.Add(value);
                root.Reorganize();
            }
        }

        public void Remove(int value)
        {
            if (root == null)
            {
                return;
            }

            if (root.IsLeaf)
            {
                root = null;
            }
            else
            {
                var node = root.Get(value);
                node.Remove();
                root.Reorganize();
            }
        }

        public bool Contains(int value)
        {
            return root.Get(value) != null;
        }

        public int Count()
        {
            return root?.Count ?? 0;
        }
    }
}
