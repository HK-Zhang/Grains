
public class BasicDemo {
	public static void main(String[] args) {
		Child child = new Child();
	}

}

class StaticVariable{
	public StaticVariable(String info)
	{
		System.out.println(info);
	}
}

class Parent{
	public static StaticVariable staticVariable = new StaticVariable("Parent - Static Variable1");
	public StaticVariable inStaticVariable = new StaticVariable("Parent - Instant Variable1");
	
	static
	{
		System.out.println("Parent - Static block/constructor");
		System.out.println(staticVariable == null); 
		//System.out.println(staticVariable2 == null); not working because staticVariable2 is not defined
		staticVariable2 = new StaticVariable("Parent - Static Variable2 -  Static block");
	}
	
	{
		System.out.println("Parent - Initializer Block");
	}
	
	public static StaticVariable staticVariable2 = new StaticVariable("Parent - Static Variable2");
	public StaticVariable inStaticVariable2 = new StaticVariable("Parent - Instant Variable2");
	
	public Parent()
	{
		System.out.println("Parent - Instance Constructor");
	}
}

class Child extends Parent{
	public static StaticVariable staticVariable = new StaticVariable("Child - Static Variable1");
	public StaticVariable inStaticVariable = new StaticVariable("Child - Instant Variable1");
	
	static
	{
		System.out.println("Child - Static block/constructor");
	}
	
	public Child()
	{
		System.out.println("Child - Instance Constructor");
	}
	
	{
		System.out.println("Child - Initializer Block");
	}
	
	public static StaticVariable staticVariable2 = new StaticVariable("Child - Static Variable2");
	public StaticVariable inStaticVariable2 = new StaticVariable("Child - Instant Variable2");
}

