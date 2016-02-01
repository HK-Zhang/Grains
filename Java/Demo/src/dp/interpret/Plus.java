package dp.interpret;

public class Plus implements IExpression {

	@Override
	public int interpret(Context ctx) {
	return ctx.getNum1()+ctx.getNum2();
	}

}
