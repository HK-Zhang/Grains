package dp.observer;

import java.util.Enumeration;
import java.util.Vector;

public abstract class AbstractSubject implements ISubject {

	private Vector<IObserver> Observers = new Vector<IObserver>();
	@Override
	public void add(IObserver observer) {
		Observers.add(observer);

	}

	@Override
	public void del(IObserver observer) {
		Observers.remove(observer);

	}

	@Override
	public void notifyObservers() {
		Enumeration<IObserver> enumo = Observers.elements();
		while(enumo.hasMoreElements()){  
			enumo.nextElement().update();  
		}

	}


}
