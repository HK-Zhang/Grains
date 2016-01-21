package dp;

import dp.decorator.*;

public class DecoratorTest {

	public static void main(String[] args) {
		ISourceable src =  new Source();
		ISourceable obj = new Decorator(src);
		obj.method();
	}

}
