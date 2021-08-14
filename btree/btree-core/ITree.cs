using System;
using System.Collections.Generic;
using System.Text;

namespace ReeX.Btree.Core
{
    public interface ITree
    {
        void Add(int value);
        int Count();
        bool Contains(int value);
    }
}
