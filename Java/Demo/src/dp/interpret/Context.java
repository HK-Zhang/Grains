package dp.interpret;

public class Context {
	private int num1;
	private int num2;
	
	public int getNum1() {
		return num1;
	}
	
	public int getNum2() {
		return num2;
	}
	
	public void setNum1(int num1) {
		this.num1 = num1;
	}
	
	public void setNum2(int num2) {
		this.num2 = num2;
	}
	
	public Context(int v1,int v2) {
		num1 =v1;
		num2 =v2;
	}

} 
