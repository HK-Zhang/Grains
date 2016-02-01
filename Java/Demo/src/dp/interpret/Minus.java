package dp.interpret;

public class Minus implements IExpression {

	@Override
	public int interpret(Context ctx) {
		return ctx.getNum1()-ctx.getNum2();
	}

}
