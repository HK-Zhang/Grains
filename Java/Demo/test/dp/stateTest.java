package dp;

import dp.state.Context;
import dp.state.State;

public class stateTest {

	public static void main(String[] args) {
		State state = new State();
		Context ctxContext = new Context(state);
		state.setValue("state1");
		ctxContext.method();
		state.setValue("state2");
		ctxContext.method();
	}

}
