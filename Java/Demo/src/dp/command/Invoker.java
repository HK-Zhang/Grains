package dp.command;

public class Invoker {
	private ICommand command;
	
	public Invoker(ICommand val) {
		command=val;
	}
	
	public void action() {
		command.exe();
	}

}
