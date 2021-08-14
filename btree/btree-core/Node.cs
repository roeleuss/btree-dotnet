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
            Children = new Node[ROOT];
        }

        public Node Parent { get; set; }
        public int Side { get; set; }
        public int Value { get; set; }
        public Node[] Children { get; set; }
        public int Count { get; set; }


        public void Add(int value)
        {
            if (value == Value) return;
            var index = (value < Value) ? 0 : 1;
            if (Children[index] != null) Children[index].Add(value);

            Children[index] = new Node()
            {
                Count = 1,
                Parent = this,
                Side = index,
                Value = value
            };

            IncrementCount();
        }

        private void IncrementCount()
        {
            Count++;
            Parent?.IncrementCount();
        }

        public Node Get(int value)
        {
            if (Value == value) return this;
            return Children[LEFT]?.Get(value) ?? Children[RIGHT]?.Get(value);
        }
    }
}
