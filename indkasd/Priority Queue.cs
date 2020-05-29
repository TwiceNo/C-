using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace indkasd
{
    struct Node
    {
        public int node, distance, heuristic, parent;

        public Node(int node, int distance, int heuristic, int parent)
        {
            this.node = node; this.distance = distance; this.heuristic = heuristic; this.parent = parent;
        }
    }

    class Priority_Queue
    {
        List<Node> queue;

        public Priority_Queue()
        {
            queue = new List<Node>();
        }

        public void Add(Node new_node)
        {
            int index = Enqueued(new_node.node);
            if (index != -1)
            {
                if (queue[index].distance > new_node.distance)
                    queue[index] = new_node;
            }
            else
                queue.Add(new_node);
            Order();
        }

        private void Order()
        {
            for (int i = queue.Count - 1; i > 0; i--)
                if (queue[i].heuristic < queue[i - 1].heuristic)
                {
                    Node temp = queue[i]; queue[i] = queue[i - 1]; queue[i - 1] = temp;
                }
        }

        public Node Front()
        {
            return queue[0];
        }

        public Node Pick()
        {
            Node node = queue[0];
            queue.Remove(node);
            return node;
        }

        public int Enqueued(int node_to_find)
        {
            for (int i = 0; i < queue.Count; i++)
                if (queue[i].node == node_to_find)
                    return i;
            return -1;
        }

        public int Length()
        {
            return queue.Count();
        }
    }
}
