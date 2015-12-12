using System;

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

		public static void Main (string[] args)
		{
			Node d = new Node (null, null, 1);
			Node e = new Node (null, null, 4);
			Node f = new Node (null, null, 7);
			Node g = new Node (null, null, 12);

			Node b = new Node (d, e, 3);
			Node c = new Node (f, g, 10);
			Node a = new Node (b, c, 5);
			Node y = a.getRight();
			int x = y.getValue ();
			Console.WriteLine ("Value:"+ x);
		
			Console.WriteLine ("Hello World!");
		}
	}

}
