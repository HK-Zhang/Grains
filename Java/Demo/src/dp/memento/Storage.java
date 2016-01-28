package dp.memento;

public class Storage {

	private Memento memento;
	
	public Memento getMemento() {
		return memento;
	}
	
	public void setMemento(Memento memento) {
		this.memento = memento;
	}
	
	public Storage(Memento obj) {
		this.memento=obj;
	}
}
