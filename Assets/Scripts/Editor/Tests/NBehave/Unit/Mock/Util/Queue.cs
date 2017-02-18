using System.Collections;

namespace Auroratide.NBehave.Unit.Mock {
    public class Queue<T> {
        private System.Collections.Generic.Queue<T> queue;

        public Queue() {
            queue = new System.Collections.Generic.Queue<T>();
        }

        public void Enqueue(T obj) {
            queue.Enqueue(obj);
        }

        public T Dequeue() {
            if(queue.Count > 0)
                return queue.Dequeue();
            else
                return default(T);
        }
    }
}