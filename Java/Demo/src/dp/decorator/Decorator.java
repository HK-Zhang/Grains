package dp.decorator;

public class Decorator implements ISourceable {

	private ISourceable source;
	
	public Decorator(ISourceable src) {
		super();
		source = src;
	}
	
	@Override
	public void method() {
		System.out.println("before decorator");
		source.method();
		System.out.println("after decorator");
	}

}
