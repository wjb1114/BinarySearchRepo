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

        public int Count { get; private set; }
        public int Depth { get; private set; }
        public int MaxDepth { get; private set; }

        public BinarySearchTree(Node rootNode)
        {
            root = rootNode;
            Count = 1;
            Depth = 1;
            MaxDepth = 1;
        }

        public BinarySearchTree(int rootValue)
        {
            root = new Node(rootValue);
            Count = 1;
            Depth = 1;
            MaxDepth = 1;
        }

        public void Add(int value)
        {
            int newDepth = 1;
            Node foundNode;
            try
            {
                foundNode = TraverseTreeToAdd(root, value, newDepth);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Error: " + e.Message);
                return;
            }
            Count++;
            GetMaxDepth();
            if (foundNode.value < value)
            {
                foundNode.right = new Node(value);
            }
            else
            {
                foundNode.left = new Node(value);
            }
            if (Depth > MaxDepth)
            {
                CorrectTree();
            }
        }

        private Node TraverseTreeToAdd(Node currentNode, int value, int depth)
        {
            if (value < currentNode.value)
            {
                if (currentNode.left != null)
                {
                    return TraverseTreeToAdd(currentNode.left, value, depth+1);
                }
                else
                {
                    if (Depth <= depth)
                    {
                        Depth = depth + 1;
                    }
                    return currentNode;
                }
            }
            else if (value > currentNode.value)
            {
                if (currentNode.right != null)
                {
                    return TraverseTreeToAdd(currentNode.right, value, depth+1);
                }
                else
                {
                    if (Depth <= depth)
                    {
                        Depth = depth + 1;
                    }
                    return currentNode;
                }
            }
            else
            {
                throw new InvalidOperationException("Value already exists in tree.");
            }
        }

        public bool Search(int value)
        {
            Node foundNode = TraverseTreeToSearch(root, value);
            if (foundNode.value != value)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private Node TraverseTreeToSearch(Node currentNode, int value)
        {
            if (value < currentNode.value)
            {
                if (currentNode.left != null)
                {
                    return TraverseTreeToSearch(currentNode.left, value);
                }
                else
                {
                    return currentNode;
                }
            }
            else if (value > currentNode.value)
            {
                if (currentNode.right != null)
                {
                    return TraverseTreeToSearch(currentNode.right, value);
                }
                else
                {
                    return currentNode;
                }
            }
            else
            {
                return currentNode;
            }
        }

        private void GetMaxDepth()
        {
            MaxDepth = 0;
            for (int i = 1; i <= Count; i*= 2)
            {
                MaxDepth++;
            }
        }

        private void CorrectTree()
        {
            List<int> vals = GetCurrentItems(root);
            vals.Sort();
            int length = vals.Count;
            int splitIndex = vals.Count / 2;
            root = new Node(vals[splitIndex]);
            vals.RemoveAt(splitIndex);
            Depth = 1;
            AddCorrectedTreeItems(vals);
            Count = length;
            GetMaxDepth();
        }

        private List<int> GetCurrentItems(Node currentNode)
        {
            List<int> selectedVals = new List<int>();
            selectedVals.Add(currentNode.value);
            if (currentNode.left != null)
            {
                List<int> leftItems = (GetCurrentItems(currentNode.left));
                for (int i = 0; i < leftItems.Count; i++)
                {
                    selectedVals.Add(leftItems[i]);
                }
            }
            if (currentNode.right != null)
            {
                List<int> rightItems = (GetCurrentItems(currentNode.right));
                for (int i = 0; i < rightItems.Count; i++)
                {
                    selectedVals.Add(rightItems[i]);
                }
            }
            return selectedVals;
        }

        private void AddCorrectedTreeItems(List<int> values)
        {
            List<int> lower = new List<int>();
            List<int> upper = new List<int>();

            while (values.Count > 1)
            {
                lower.Add(values[0]);
                upper.Add(values[values.Count - 1]);
                values.RemoveAt(0);
                values.RemoveAt(values.Count - 1);
            }
            if (values.Count == 1)
            {
                lower.Add(values[0]);
                values.RemoveAt(0);
            }
            
            int lowerSplitIndex = lower.Count / 2;
            int upperSplitIndex = upper.Count / 2;
            if (upper.Count > 0)
            {
                Add(upper[upperSplitIndex]);
                upper.RemoveAt(upperSplitIndex);
            }
            if (lower.Count > 0)
            {
                Add(lower[lowerSplitIndex]);
                lower.RemoveAt(lowerSplitIndex);
            }
            if (lower.Count > 0)
            {
                AddCorrectedTreeItems(lower);
            }
            if (upper.Count > 0)
            {
                AddCorrectedTreeItems(upper);
            }
        }
    }
}
