package demo;

public class ExceptionDemo {
	public static void main(String[] args) {
		//Test1();
		Test2();
		
	}
	
	private static void Test1() {
		TestException te = new TestException();
		try {
			te.method1();
		} catch (CException e) {
			// TODO: handle exception
			e.printStackTrace();
		}
	}
	
	private static void Test2() {
		TestException te = new TestException();
		te.method2("Hello");
		te.method2(null);
	}

}

class CException extends Exception{
	public CException() {
		
	}
	
	public CException(String messageString) {
		super(messageString);
		
	}
	
}

class TestException{
	public void method1() throws CException {
		throw(new CException("Test Exception"));
	}
	
	public void method2(String msgString) {
		if(msgString==null)
		{
			throw new NullPointerException("Message is null");
		}
	}
	
	public void method3() throws CException {
		method1();
	}
}
