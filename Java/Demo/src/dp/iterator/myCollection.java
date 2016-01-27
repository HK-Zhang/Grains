package dp.iterator;

public class myCollection implements ICollection {
	
	public String str[] = {"A","B","C","D","E"};  

	@Override
	public IIterator iterator() {
		return new myIterator(this);
	}

	@Override
	public int size() {
		return str.length;
	}

	@Override
	public Object get(int i) {
		return str[i];
	}

}
