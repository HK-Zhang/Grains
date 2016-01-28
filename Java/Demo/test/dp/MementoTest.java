package dp;

import dp.memento.*;

public class MementoTest {

	public static void main(String[] args) {
		Original origi = new Original("egg");
		Storage strg = new Storage(origi.createMemento());
		
		System.out.println("Initial status:"+origi.getValue());
		origi.setValue("niu");
		System.out.println("New status:"+origi.getValue());
		
		origi.restoreMemento(strg.getMemento());
		System.out.println("restored status:"+origi.getValue());

	}

}
