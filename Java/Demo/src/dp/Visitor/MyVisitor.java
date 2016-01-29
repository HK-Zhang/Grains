package dp.Visitor;

public class MyVisitor implements IVisitor {

	@Override
	public void visit(ISubject sub) {
		System.out.println("Visit the subject"+sub.getSubject());

	}

}
