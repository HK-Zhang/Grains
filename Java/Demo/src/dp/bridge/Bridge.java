package dp.bridge;

import dp.decorator.ISourceable;

public abstract class Bridge {
	private ISourceable source;
	
	public void method() {
		source.method();
	}
	
	public ISourceable getSource()
	{
		return source;
	}
	
	public void setSource(ISourceable value) {
		this.source=value;
	}

}
