package dp.command;

public class MyCommand implements ICommand {

	private Receiver receiver;
	
	public MyCommand(Receiver val) {
		receiver=val;
	}
	
	@Override
	public void exe() {
		receiver.action();

	}

}
