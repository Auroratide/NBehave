using System.Collections;

namespace Auroratide.NBehave.Unit.Mock {
    public class Dictionary<K, V> {
        private System.Collections.Generic.Dictionary<K, V> dictionary;

        public Dictionary() {
            dictionary = new System.Collections.Generic.Dictionary<K, V>();
        }

        public V Get(K key) {
            if(dictionary.ContainsKey(key))
                return dictionary[key];
            else
                return default(V);
        }

        public void Set(K key, V value) {
            dictionary[key] = value;
        }

    }
}