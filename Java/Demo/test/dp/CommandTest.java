package dp;

import dp.command.*;

public class CommandTest {

	public static void main(String[] args) {
		Receiver receiver = new Receiver();
		ICommand cmd = new MyCommand(receiver);
		Invoker ivk = new Invoker(cmd);
		ivk.action();

	}

}
