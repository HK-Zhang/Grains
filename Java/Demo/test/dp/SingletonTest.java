package dp;

import dp.singleton.*;

public class SingletonTest {

	public static void main(String[] args) {
		Singleton sglSingleton = Singleton.getInstance();
		sglSingleton.Action();
		
		SingletonB sglSingletonB = SingletonB.GetInstance();
		sglSingletonB.Action();
	}

}
