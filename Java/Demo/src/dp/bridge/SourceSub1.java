package dp.bridge;

import dp.decorator.ISourceable;

public class SourceSub1 implements ISourceable {

	@Override
	public void method() {
		System.out.println("This is the first sub");

	}

}
