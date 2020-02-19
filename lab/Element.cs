using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab3
{
    public class Element<K, V> where K : IComparable<K>
    {

        // Properties
        public K key { get; private set; }
        public V value { get; private set; }

        // Constructor
        public Element(K key, V value)
        {
            this.key = key;
            this.value = value;
        }

    }
}
