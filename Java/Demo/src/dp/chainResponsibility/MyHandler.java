package dp.chainResponsibility;

public class MyHandler extends AbstractHandler implements IHandler {
	
	private String name;
	
	public MyHandler(String val) {
		name=val;
	}

	@Override
	public void operate() {
		System.out.println(name+"deal!");
		if(getHandler()!=null)
		{
			getHandler().operate();
		}

	}

}
