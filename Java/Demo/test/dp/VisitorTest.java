package dp;

import dp.Visitor.*;

public class VisitorTest {

	public static void main(String[] args) {
		IVisitor visitor = new MyVisitor();
		ISubject subject = new MySubject();
		subject.accept(visitor);

	}

}
