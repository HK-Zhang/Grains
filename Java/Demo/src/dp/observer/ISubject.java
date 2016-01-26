package dp.observer;

public interface ISubject {
	public void add(IObserver observer);
	public void del(IObserver observer);
	public void notifyObservers();
	public void operation();

}
