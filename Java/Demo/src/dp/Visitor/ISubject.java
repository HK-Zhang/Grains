package dp.Visitor;

public interface ISubject {
	public void accept(IVisitor visitor);
	public String getSubject();

}
