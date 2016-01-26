package dp.templateMethod;

public abstract class AbstractCalculatorTM {
	public final int calculate(String exp, String opt) {
		int array[]=split(exp, opt);
		return calculate(array[0], array[1]);
		
	}
	
	abstract protected int calculate(int num1,int num2);

	public int[] split(String exp,String opt) {
		String array[] = exp.split(opt);
		int arrayint[] = new int[2];
		arrayint[0]= Integer.parseInt(array[0]);
		arrayint[1] = Integer.parseInt(array[1]);
		return arrayint;
	}
}
