package dp.mediator;

public class User1 extends User {

	public User1(IMediator value) {
		super(value);
	}
	
	@Override
	public void work() {
		System.out.println("User1 exe!");

	}

}
