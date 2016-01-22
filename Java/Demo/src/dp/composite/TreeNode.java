package dp.Composite;

import java.util.Enumeration;
import java.util.Vector;

public class TreeNode {
	private String name;
	private TreeNode parentNode;
	private Vector<TreeNode> childrenNodes =new Vector<TreeNode>();

	public TreeNode(String nameString) {
		this.name=nameString;
	}
	
	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		this.name = name;
	}
	
	public TreeNode getParentNode() {
		return parentNode;
	}
	
	public void setParentNode(TreeNode parentNode) {
		this.parentNode = parentNode;
	}
	
	public void add(TreeNode node) {
		childrenNodes.add(node);
	}
	
	public void remove(TreeNode node) {
		childrenNodes.remove(node);
	}
	
	public Enumeration<TreeNode> getChildren(){  
	return childrenNodes.elements();  
	}

	
}
