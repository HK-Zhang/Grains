package dp.memento;

public class Original {

	private String value;
	
	public String getValue() {
		return value;
	}
	
	public void setValue(String value) {
		this.value = value;
	}
	
	public Original(String val) {
		value=val;
	}
	
	public Memento createMemento() {
		return new Memento(value);
	}
	
	public void restoreMemento(Memento obj) {
		this.value=obj.getValue();
	}
}
