package dp;

import dp.mediator.*;

public class MediatorTest {

	public static void main(String[] args) {
		IMediator mediator = new MyMediator();
		mediator.createMediator();
		mediator.workAll();

	}

}
