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
        [InlineData(200)]
        [InlineData(200, 300)]
        [InlineData(200, 100)]
        [InlineData(200, 300, 400)]
        [InlineData(200, 300, 400, 500, 600)]
        [InlineData(200, 300, 400, 500, 600, 450, 550)]
        public void GivenAddedValues_ThenValuesNeedContainAtTree(params int[] values)
        {
            BinaryTree tree = new BinaryTree();
            foreach(int value in values) 
                tree.Add(value);
            foreach (int value in values) 
                Assert.True(tree.Contains(value), $"Not Found {value}");
            Assert.Equal(values.Length, tree.Count());
        }
    }
}
