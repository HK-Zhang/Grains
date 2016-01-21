package dp.Proxy;

import dp.decorator.ISourceable;
import dp.decorator.Source;

public class Proxy implements ISourceable {

	private Source source;
	
	public Proxy() {
		super();
		this.source = new Source();
	}
	
	@Override
	public void method() {
		before();
		source.method();
		after();
	}
	
	private void after() {
		System.out.println("after proxy");
	}
	
	private void before() {
		System.out.println("before proxy");
	}

}
