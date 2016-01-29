package dp.state;

public class Context {
	private State state;
	
	public State getState() {
		return state;
	}
	
	public void setState(State state) {
		this.state = state;
	}
	
	public Context(State val) {
		state = val;
	}
	
	public void  method() {
		if(state.getValue().equals("state1"))
		{
			state.method1();
		}
		else {
			state.method2();
		}
	}

}
