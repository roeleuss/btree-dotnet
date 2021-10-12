using System;

namespace ReeX.Btree.Core
{
    public class Node
    {
        public const int LEFT = 0;
        public const int RIGHT = 1;
        public const int ROOT = 2;

        public Node()
        {
            Count = 1;
        }

        public Node Parent { get; set; }
        public int Side { get; set; }
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Count { get; set; }


        public void Add(int value)
        {
            if (value == Value) return;

            if (value < Value)
            {
                if (Left == null)
                {
                    Left = CreateNode(value, LEFT);
                }
                else
                {
                    Left.Add(value);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = CreateNode(value, RIGHT);
                }
                else
                {
                    Right.Add(value);
                }
            }
        }
        public void Reorganize()
        {
            if (Balance < -1)
            {
                Node toRemove = Left.Max();
                Node toAdd = Right?.Min();
                Reorganize(toRemove, toAdd);
            }
            else if (Balance > 1)
            {
                Node toRemove = Right.Min();
                Node toAdd = Left?.Max();
                Reorganize(toRemove, toAdd);
            }
        }

        private void Reorganize(Node toRemove, Node toAdd)
        {
            var rootValue = Value;
            Value = toRemove.Value;
            toRemove.Remove();
            (toAdd ?? this).Add(rootValue);
            Left?.Reorganize();
            Right?.Reorganize();
        }

        public void Remove()
        {
            if (IsLeaf)
            {
                switch (Side)
                {
                    case LEFT:
                        Parent.Left = null;
                        Parent.DecrementCount();
                        break;
                    case RIGHT:
                        Parent.Right = null;
                        Parent.DecrementCount();
                        break;
                }
            }
            else
            {
                Node toReplace = Balance <= 0 ? Left.Max() : Right.Min();
                Value = toReplace.Value;
                toReplace.Remove();
            }
        }

        public bool IsLeaf => Count == 1;

        public int Balance => (Right?.Count ?? 0) - (Left?.Count ?? 0);


        public Node Max()
        {
            Node node = this;
            while (node.Right != null) node = node.Right;
            return node;
        }

        public Node Min()
        {
            Node node = this;
            while (node.Left != null) node = node.Left;
            return node;
        }

        private Node CreateNode(int value, int side)
        {
            IncrementCount();

            return new Node()
            {
                Count = 1,
                Parent = this,
                Side = side,
                Value = value
            };
        }

        private void IncrementCount()
        {
            Count++;
            Parent?.IncrementCount();
        }

        private void DecrementCount()
        {
            Count--;
            Parent?.DecrementCount();
        }

        public Node Get(int value)
        {
            if (value == Value) return this;
            if (value < Value)
            {
                if (Left != null)
                {
                    return Left.Get(value);
                }
            }
            else
            {
                if (Right != null)
                {
                    return Right.Get(value);
                }
            }
            return null;
        }
    }
}
