package dp.singleton;

public class SingletonB {
	private volatile static SingletonB instance;
	
	private SingletonB() {

	}
	
	private static synchronized void syncInit() {
		instance = new SingletonB();
	}
	
	public static SingletonB GetInstance() {
		if(instance == null)
		{
			syncInit();
		}
		
		return instance;
	}
	
	public void Action() {
		System.out.println("Action is completed");
	}

}
