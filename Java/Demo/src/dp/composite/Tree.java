package dp.Composite;

public class Tree {

	TreeNode root = null;
	
	public Tree(String name) {
		root = new TreeNode(name);
	}
	
	public TreeNode getRoot() {
		return root;
	}
}
