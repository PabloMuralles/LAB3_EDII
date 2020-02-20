using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab3
{
    class BtreeNode<K, V> where K : IComparable<K>
    {

        // Properties
        public List<Element<K, V>> elements;
        public List<BtreeNode<K, V>> childs;
        private int order;

        /// <summary>Constructor.</summary>
        /// <param name="order">The order of the tree.</param>
        public BtreeNode(int order)
        {
            elements = new List<Element<K, V>>(order);
            childs = new List<BtreeNode<K, V>>(order);
            this.order = order;
        }

        /// <summary>Determinate if the node is a leaf.</summary>
        public bool IsLeaf => childs.Count == 0;

        /// <summary>Verify if the node has the minimum number of elements.</summary>
        public bool HasMinimum => elements.Count == (2 * order) - 1;

        /// <summary>Verify if the node is full.</summary>
        public bool IsFull => elements.Count == order - 1;

    }

}
