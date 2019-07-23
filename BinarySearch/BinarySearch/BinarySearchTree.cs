using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class BinarySearchTree
    {
        public Node root;

        public BinarySearchTree(Node rootNode)
        {
            root = rootNode;
        }

        public BinarySearchTree(int rootValue)
        {
            root = new Node(rootValue);
        }

        public void Add(int value)
        {
            Node foundNode = TraverseTreeToAdd(root, value);
            if (foundNode.value < value)
            {
                foundNode.right = new Node(value);
            }
            else
            {
                foundNode.left = new Node(value);
            }
        }

        private Node TraverseTreeToAdd(Node currentNode, int value)
        {
            if (value < currentNode.value)
            {
                if (currentNode.left != null)
                {
                    return TraverseTreeToAdd(currentNode.left, value);
                }
                else
                {
                    return currentNode;
                }
            }
            else
            {
                if (currentNode.right != null)
                {
                    return TraverseTreeToAdd(currentNode.right, value);
                }
                else
                {
                    return currentNode;
                }
            }
        }

        public bool Search(int value)
        {

        }

        // if (root.left != null)
    }
}
