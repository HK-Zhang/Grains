package dp;
import dp.interpret.*;

public class InterpretTest {

	public static void main(String[] args) {
		int result = new Minus().interpret(new Context(new Plus().interpret(new Context(1, 2)), 1));
		System.out.println(result);

	}

}
