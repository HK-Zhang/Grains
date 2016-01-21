package dp;


import dp.facade.Computer;

public class FacadeTest {

	public static void main(String[] args) {
		Computer computer = new Computer();
		computer.startup();
		computer.shutdown();

	}

}
