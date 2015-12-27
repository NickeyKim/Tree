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
		/* Max Heapify Binary Tree using Traverse */
		/*
		public static Node HeapifyTraverse(Node root)
		{
			if (root == null)
				return null;

			root.left = HeapifyTraverse(root.left);
			root.right = HeapifyTraverse(root.right);

			//sift root down
			return SiftNodeDownInBST(root);
		}

		public static Node SiftNodeDownInBST(Node node)
		{
			Node right = node.right;
			Node nodeToReturn = right;
			Node left = node.left;
			while (right != null)
			{
				node.left = right.left;
				node.right = right.right;
				right.right = SiftNodeDownInBST(node);
				right.left = left;

				right = node.right;
				left = node.left;
			}
			if (left != null)
			{
				if (left.value > node.value)
				{
					nodeToReturn = left;
					Node l = left.left;
					Node r = left.right;
					left.right = node.right;
					node.left = l;
					node.right = r;
					left.left = SiftNodeDownInBST(node);
				}
			}
			if (nodeToReturn != null)
				return nodeToReturn;
			else
				return node;
		}*/

		public void HeapifyTraverse(Node root)
		{
			if (root == null)
				return;
			HeapifyTraverse (root.getLeft());
			HeapifyTraverse (root.getRight());
			Node largest = root;
			if (root.getLeft () != null && root.getLeft ().getValue () > root.getValue()) {
				largest = root.getLeft ();
			}
			if (root.getRight () != null && root.getRight().getValue() > root.getValue()) {

				largest = root.getRight ();
			}
			if (largest != root) {
				swap (root, largest);
				}
		}
		public void swap( Node root, Node largest)  //swapping each node's left and right
		{
			int temp = root.value;
			root.value= largest.value;
			largest.value= temp;
			if (largest.right != null && largest.right.value > largest.value) {
				swap (largest, largest.right);
			}

		}
		public Node RoateRight(){
			Node newRoot = left;
			left = newRoot.right;
			newRoot.right = this;
			return newRoot;
		}
		public static Node RoateRightStatic(Node oldRoot){
			Node newRoot = oldRoot.getLeft ();
			oldRoot.left = newRoot.getRight ();
			newRoot.right = oldRoot;
			return newRoot;
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
			Console.WriteLine ("BST");
			Console.WriteLine ("   5   ");
			Console.WriteLine (" 3---10 ");
			Console.WriteLine ("1-4-7-12");
			int findval = 10;
			Node find = new Node (null, null, findval);
			find = find.findRecur (a, findval);
			if (find != null) {
				Console.WriteLine ("" +
					"Value:" + find.getValue () + " found");
			} else {
				
				Console.WriteLine ("Value:" + findval + " Not Found");
			}
			int height = findHeight (f);
			Console.WriteLine ("Height: "+height);
			a.preorder (a);
			Console.WriteLine ("->Preorder");
			a.inorder (a);
			Console.WriteLine ("->Inorder");
			a.postorder (a);
			Console.WriteLine ("->Postorder");
			a.preorderNonRecur (a);
			Console.WriteLine ("->Preorder_Not_Recursive");
			Console.WriteLine (a.LowestCommonAncestor (a, f,g ).getValue ());
			Console.WriteLine ("->LowestCommonAncestor");
			a.HeapifyTraverse (a);
			a.preorder(a);
			Console.WriteLine ("->HeapifyTraverse");
			d = new Node (null, null, 1);
			e = new Node (null, null, 3);
			f = new Node (null, null, 5);
			g = new Node (null, null, 7);

			b = new Node (d, e, 2);
			c = new Node (b, f, 4);
			a = new Node (c, g, 6);
			a.preorder (a);
			Console.WriteLine ("");
			RoateRightStatic (a);
//			a.RoateRight ();
			c.preorder (c);

		}
	}

}
