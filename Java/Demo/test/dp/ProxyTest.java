package dp;

import dp.decorator.ISourceable;
import dp.Proxy.*;

public class ProxyTest {

	public static void main(String[] args) {
		ISourceable srcISourceable = new Proxy();
		srcISourceable.method();
	}

}
