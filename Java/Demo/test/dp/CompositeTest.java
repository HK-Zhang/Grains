package dp;

import dp.Composite.*;

public class CompositeTest {

	public static void main(String[] args) {
		Tree tree = new Tree("A");
		TreeNode nodeB = new TreeNode("B");
		TreeNode nodeC = new TreeNode("C");
		
		nodeB.add(nodeC);
		tree.getRoot().add(nodeB);
		System.out.println("Build the tree finished");

	}

}
