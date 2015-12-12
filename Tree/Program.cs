using System;

/*Making Binary Tree*/
namespace Tree
{
	public class Node
	{
		private Node left;
		private Node right;
		private int value;

		public Node(Node left, Node right, int value)
		{
			this.left = left;
			this.right = right;
			this.value = value;
		}
		public Node getLeft() {return left;}
		public Node getRight() {return right;}
		public int getValue() {return value;}
		/* Lookup Binary Search Tree 
		->Compare the value with Current Node
		Starts at the head of Tree
		while CurVal != Null
		if curVal = Value, return curNode;
		else if curNode < Value, rightchild is to be CurNode
		else if curNode > Value, leftchild is to be CurNode
		if failed to find, return root
		*/
		public Node findNode(Node root, int value)
		{
			while (root != null) {
				int curVal = root.getValue ();
				if (curVal == value)
					break;
				else if (curVal < value) {
					root = root.getRight ();
				} 
				else if (curVal > value) {
					root = root.getLeft ();
				}
			}
			return root;
		}
		/* Making Recursively find Node in Binary search Tree */
		public Node findRecur(Node root, int value)
		{
			if (root == null)
				return null;
			else {
				int curVal = root.getValue ();
				if (curVal == value)
					return root;
				else if (curVal < value) {
					return findRecur (root.getRight (), value);
				} else {
					return findRecur (root.getLeft (), value);
				}
			}
		}

		public static void Main (string[] args)
		{
			Node d = new Node (null, null, 1);
			Node e = new Node (null, null, 4);
			Node f = new Node (null, null, 7);
			Node g = new Node (null, null, 12);

			Node b = new Node (d, e, 3);
			Node c = new Node (f, g, 10);
			Node a = new Node (b, c, 5);

			Node find = new Node (null, null, 0);
			find = find.findRecur (a, 0);
			if (find != null) {
				Console.WriteLine ("Value:" + find.getValue () + " found");
			} else {
				
				Console.WriteLine ("Not Found");
			}


			Console.WriteLine ("Hello World!");
		}
	}

}
