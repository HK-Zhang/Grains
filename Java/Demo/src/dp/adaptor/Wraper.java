package dp.adaptor;

public class Wraper implements ITargetable {
	private Source src; 
	
	public Wraper(Source source) {
		super();
		src=source;
	}

	@Override
	public void method1() {
		src.method1();

	}

	@Override
	public void method2() {
		System.out.println("This is the targetable method");

	}

}
