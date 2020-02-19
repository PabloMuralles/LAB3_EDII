using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab3.Controllers;

namespace lab3.Estructura
{
    public class BTree<V, K> where K : IComparable<K>
    {
        // Properties
        public int Count { get; private set; }
        private Node<K, V> root;
        private int order;

        // Constructor
        public BTree(int order)
        {
            Count = 0;
            root = new Node<K, V>(order);
            this.order = order;
        }

        // Insert an element in the tree
        public void Insert(K key, V value)
        {
            if (root.IsFull)
            {
                Node<K, V> newChilds = root;
                root = new Node<K, V>(order);
                root.childs.Add(newChilds);
                SplitNode(root, newChilds, 0);
                InsertElement(root, key, value);
            }
            else
            {
                InsertElement(root, key, value);
            }
            Count++;
        }


        private void SplitNode(Node<K, V> parentNode, Node<K, V> split, int index)
        {
            Node<K, V> newNode = new Node<K, V>(order);
            parentNode.elements.Insert(1, split.elements[order - 1]);
            parentNode.childs.Insert(index + 1, newNode);
            newNode.elements.AddRange(split.elements.GetRange(order, order - 1));
            split.elements.RemoveRange(order - 1, order);
            if (!split.IsLeaf)
            {
                newNode.childs.AddRange(split.childs.GetRange(order, order));
                split.childs.RemoveRange(order, order);
            }

        }


        private void InsertElement(Node<K, V> currentNode, K key, V value)
        {
            int index = currentNode.elements.TakeWhile(e => key.CompareTo(e.key) >= 0).Count();
            if (currentNode.IsLeaf)
            {
                currentNode.elements.Insert(index, new Element<K, V>(key, value));
            }
            else
            {
                Node<K, V> child = currentNode.childs[index];
                if (child.IsFull)
                {
                    SplitNode(currentNode, child, index);
                    if (key.CompareTo(currentNode.elements[index].key) > 0)
                    {
                        index++;
                    }
                }
                InsertElement(currentNode.childs[index], key, value);
            }
        }


    }
}
