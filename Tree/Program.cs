using System;
using System.Collections.Generic;
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

		public void printValue()
		{
			Console.Write (value+ " ");
		}

		/* Lookup Binary Search Tree : O(logN)
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
		/* Making Recursively find Node in Binary search Tree :O(logN)
		*/
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
		/* find the height of tree in Binary Tree : O(n)
		 * -> the maximum distance of root node to leaf node */
		public static int findHeight (Node root) {
			if (root == null)
				return 0;
			return 1 + Math.Max (findHeight(root.getLeft()), findHeight(root.getLeft()));
		}
		/* Preorder Traversal : O(n)
		 * if root == null return;
		 * print root;
		 * recursively print left child;
		 * recursively print right child; */
		public void preorder(Node root){
			if (root == null)
				return;
			root.printValue ();
			preorder (root.getLeft ());
			preorder (root.getRight ());
		}
		/* Inorder Traversal  : O(n)
		 * if root = null return;
		 * recursively print left child;
		 * print root;
		 * recursively print right child; */
		public void inorder (Node root){
			if (root == null)
				return;
			inorder (root.getLeft ());
			root.printValue ();
			inorder (root.getRight ());
		}
		/* postorder Traversal :  O(n)
		 * if root= null return;
		 * recursively print left child;
		 * recursively print right child;
		 * print root;*/
		public void postorder( Node root){
			if (root == null)
				return;
			postorder (root.getLeft ());
			postorder (root.getRight ());
			root.printValue();
		}
		/*Preorder Traversal non-recursive : O(n) (is free of Overhead)
		 * Make a stack
		 * insert root in Stack
		 * while(stack not empty)
		 * 	pop curNode
		 *  print curNode
		 *  if it has right child, insert child in Stack
		 *  if it has left child, insert child in Stack */
		public void preorderNonRecur(Node root){
			Stack<Node> stack=new Stack<Node>();
			stack.Push(root);

			while(stack.Count>0){
				Node curNode=stack.Pop();
				curNode.printValue();

				Node n=curNode.getRight();
				if(n!=null) stack.Push(n);

				n = curNode.getLeft ();
				if(n!=null) stack.Push(n);
			}
		}
		/* Find Lowest Common Ancestor : O(logN)
		 * starts at the root
		 * while curNode != null
		 * if curNode > valueA and valueB
		 * 	go to the left child
		 * if curNode < valueA and valueB
		 *  go to the right child
		 * else return curNode */
		public Node LowestCommonAncestor(Node root, int valueA, int valueB){
			while (root != null) {
				int rootval = root.getValue ();
				if (rootval > valueA && rootval > valueB) {
					root = root.getLeft ();
				} else if (rootval < valueA && rootval < valueB) {
					root = root.getRight ();
				} else {
					return root;
				}
			}
			return null;
		}
		/* overload LowestCommonAncestor to get the reference of two nodes */
		public Node LowestCommonAncestor(Node root, Node nodeA, Node nodeB){
			if (root == null || nodeA == null || nodeB == null)
				return null;
			return LowestCommonAncestor(root, nodeA.getValue(), nodeB.getValue());
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
			int height = findHeight (f);
			Console.WriteLine ("Height: "+height);
			a.preorder (a);
			Console.WriteLine ("");
			a.inorder (a);
			Console.WriteLine ("");
			a.postorder (a);
			Console.WriteLine ("");
			a.preorderNonRecur (a);
			Console.WriteLine ("");
			Console.WriteLine (a.LowestCommonAncestor (a, f,g ).getValue ());
		}
	}

}
