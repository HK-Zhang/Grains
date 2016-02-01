package dp.mediator;

public abstract class User {
	private IMediator mediator;
	
	public IMediator getMediator() {
		return mediator;
	}
	
	public User(IMediator value) {
		mediator = value;
	}
	
	public abstract void work();

}
