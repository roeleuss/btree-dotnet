using ReeX.Btree.Core;
using System;
using Xunit;

namespace ReeX.Btree.Test
{
    public class BinaryTreeTest
    {
        [Fact]
        public void GivenEmptyBinaryTree_ThenCountMustBeZero()
        {
            BinaryTree tree = new BinaryTree();
            Assert.Equal(0, tree.Count());
        }

        [Theory]
        [InlineData(20)]
        public void GivenFirstValueAdded_ThenValueNeedsContainInTree(int value)
        {
            BinaryTree tree = new BinaryTree();
            tree.Add(value);
            Assert.True(tree.Contains(value));
            Assert.Equal(1, tree.Count());
        }
    }
}
