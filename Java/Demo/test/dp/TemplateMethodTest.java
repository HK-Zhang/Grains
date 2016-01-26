package dp;

import dp.templateMethod.*;

public class TemplateMethodTest {

	public static void main(String[] args) {
		String exp = "8+8"; 
		AbstractCalculatorTM calculatorTM=new PlusTM();
		int result=calculatorTM.calculate(exp, "\\+");
		System.out.println(result);

	}

}
