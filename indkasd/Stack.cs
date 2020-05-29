using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace indkasd
{
    struct ColorNode
    {
        public int node; public string color;

        public ColorNode(int node, string color)
        {
            this.node = node; this.color = color;
        }
    }


    class Stack
    {
        List<ColorNode> stack;

        public Stack()
        {
            stack = new List<ColorNode>();
        }

        public void Add(ColorNode node)
        {
            stack.Add(node);
        }

        public ColorNode Pick()
        {
            ColorNode node = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return node;
        }
    }
}
