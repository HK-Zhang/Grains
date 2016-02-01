package dp.mediator;

public class MyMediator implements IMediator {
	private User1 user1;
	private User2 user2;
	
	public User1 getUser1() {
		return user1;
	}
	
	public User2 getUser2() {
		return user2;
	}

	public MyMediator() {
		
	}

	@Override
	public void createMediator() {
		user1 = new User1(this);
		user2 = new User2(this);

	}

	@Override
	public void workAll() {
		user1.work();
		user2.work();

	}

}
