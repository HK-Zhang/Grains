package dp.Visitor;

public class MySubject implements ISubject {

	@Override
	public void accept(IVisitor visitor) {
		visitor.visit(this);

	}

	@Override
	public String getSubject() {
		return "love";
	}

}
