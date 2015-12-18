import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;


public class BasicDemo {
	public static void main(String[] args)  throws ParseException {
		//Child child = new Child();
		
/*		ParentDef pdf = new ParentDef();
		ParentDef pcdf = new ChildRef();
		ChildRef cdf = new ChildRef();
		System.out.println("V1");
		System.out.println(pdf.STATICVALUE_STRING);
		System.out.println(pdf.valueString);
		
		System.out.println("V2");
		System.out.println(pcdf.STATICVALUE_STRING);
		System.out.println(pcdf.valueString);
		
		System.out.println("V3");
		System.out.println(cdf.STATICVALUE_STRING);
		System.out.println(cdf.valueString);*/
		
        test1();
        test2();
        test3();
		
	}
	
    private static void test1() throws ParseException
    {
        Date date = new Date();
        System.out.println(date);
        DateFormat sf = new SimpleDateFormat("yyyy-MM-dd");
        System.out.println(sf.format(date));
        String formatString = "2013-05-12";
        System.out.println(sf.parse(formatString));
    }
    
    private static void test2()
    {
        Date date = new Date();
        System.out.println("Year:" + date.getYear());
        System.out.println("Month:" + date.getMonth());
        System.out.println("Day:" + date.getDate());
        System.out.println("Hour:" + date.getHours());
        System.out.println("Minute:" + date.getMinutes());
        System.out.println("Second:" + date.getSeconds());
        System.out.println("DayOfWeek:" + date.getDay());
    }
    
    private static void test3()
    {
        Calendar c = Calendar.getInstance();
        System.out.println(c.getTime());
        System.out.println(c.getTimeZone());
        System.out.println("Year:" + c.get(Calendar.YEAR));
        System.out.println("Month:" + c.get(Calendar.MONTH));
        System.out.println("Day:" + c.get(Calendar.DATE));
        System.out.println("Hour:" + c.get(Calendar.HOUR));
        System.out.println("HourOfDay:" + c.get(Calendar.HOUR_OF_DAY));
        System.out.println("Minute:" + c.get(Calendar.MINUTE));
        System.out.println("Second:" + c.get(Calendar.SECOND));
        System.out.println("DayOfWeek:" + c.get(Calendar.DAY_OF_WEEK));
        System.out.println("DayOfMonth:" + c.get(Calendar.DAY_OF_MONTH));
        System.out.println("DayOfYear:" + c.get(Calendar.DAY_OF_YEAR));
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

class ParentDef{
	public static final String STATICVALUE_STRING="Parent Static Variable";
	public String valueString="Parent Instant Variable";
}

class ChildRef extends ParentDef{
	public static final String STATICVALUE_STRING="Child Static Variable";
	public String valueString="Child Instant Variable";
}

