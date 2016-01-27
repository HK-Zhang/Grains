package dp.iterator;

public class myIterator implements IIterator {
	
	private ICollection collection;
	private int pos =-1;
	
	public myIterator(ICollection val) {
		collection=val;
	}

	@Override
	public Object previous() {
		if(pos>0)
		{
			--pos;
		}
		return collection.get(pos);
	}

	@Override
	public Object next() {
		if(pos<collection.size()-1)
		{
			++pos;
		}
		return collection.get(pos);
	}

	@Override
	public boolean hasNext() {
		if(pos<collection.size()-1)
		{
			return true;
		}
		else
		{
			return false;
		}
		
	}

	@Override
	public Object first() {
		pos=0;
		return collection.get(pos);
	}

}
