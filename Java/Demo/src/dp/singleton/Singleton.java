package dp.singleton;

public class Singleton {

	private Singleton() {
		
	}
	
	private static class SingletonFactory{
		private static Singleton instance = new Singleton();  
	}
	
	public static Singleton getInstance() {
		return SingletonFactory.instance;
	}
	
	public Object readResolve() {
		return getInstance();
	}
	
	public void Action() {
		System.out.println("Action is completed");
	}
}
