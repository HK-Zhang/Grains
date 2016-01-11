import java.lang.annotation.Annotation;
import java.lang.annotation.Documented;
import java.lang.annotation.ElementType;
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.Target;
import java.lang.reflect.Field;
import java.lang.reflect.InvocationHandler;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.util.Iterator;

import javax.activation.FileDataSource;


public class ReflectionDemo {

	public static void main(String[] args) throws ClassNotFoundException, InstantiationException, IllegalAccessException, NoSuchMethodException, SecurityException, IllegalArgumentException, InvocationTargetException, NoSuchFieldException {
		// TODO Auto-generated method stub
		printClassTypeInfo("myHelloWorld");
		createInstanceTest("myHelloWorld");
		invokeMethodTest("myHelloWorld");
		setFieldTest("myHelloWorld");
		annotationTest();

	}
	
	static void printClassTypeInfo(String typeString)throws ClassNotFoundException
	{
		Class typeClass=Class.forName(typeString);
		
		System.out.println("Methods Info as below:");
		
		Method[] methods = typeClass.getDeclaredMethods();
		for(Method method:methods){
			System.out.println(method.toGenericString());
		}
		
		System.out.println("Fields Info as below:");
		Field[] fields = typeClass.getFields();
		for(Field field:fields){
			System.out.println(field.toGenericString());
		}
		
	}
	
	static void createInstanceTest(String typeString) throws ClassNotFoundException,InstantiationException,IllegalAccessException
	{
		Class typeClass = Class.forName(typeString);
		myHelloWorld hello = (myHelloWorld)typeClass.newInstance();
		hello.sayHello("World");
		
	}
	
	static void invokeMethodTest(String typeString) throws InstantiationException,IllegalAccessException,ClassNotFoundException,NoSuchMethodException,SecurityException,IllegalArgumentException,InvocationTargetException
	{
		Class typeClass =Class.forName(typeString);
		myHelloWorld hello = (myHelloWorld)typeClass.newInstance();
		Method method = typeClass.getMethod("sayHello", new Class[]{String.class});
		method.invoke(hello, new Object[]{"World"});
		
	}
	
	static void setFieldTest(String typeString) throws ClassNotFoundException,NoSuchFieldException,SecurityException,InstantiationException,IllegalAccessException
	{
		Class typeClass = Class.forName(typeString);
		myHelloWorld hello = (myHelloWorld)typeClass.newInstance();
		System.out.println("name is"+hello.name);
		Field field=typeClass.getField("name");
		field.set(hello, "China");
		System.out.println("name is"+hello.name);
	}
	
	static void annotationTest(){
		myDemoClass dClass = new myDemoClass();
		Annotation[] annotations = dClass.getClass().getAnnotations();
		for(Annotation a:annotations){
			System.out.println(a.toString());
		}
		
		Method[] methods=dClass.getClass().getDeclaredMethods();
		Field[] fields = dClass.getClass().getFields();
		
		for(Method m:methods){
			annotations=m.getAnnotations();
			for(Annotation a:annotations){
				System.out.println(a.toString());
			}
			
			Annotation[][] paraAnnotations = m.getParameterAnnotations();
			for(int i = 0; i < paraAnnotations.length; i++){
			for(Annotation a:paraAnnotations[i]){
				System.out.println(a.toString());
			}
			}
		}
		
		for(Field f:fields){
			annotations=f.getAnnotations();
			for(Annotation a:annotations){
				System.out.println(a.toString());
			}
		}
			
	
	}

}

interface HelloWorldService{
	void sayHello(String name);
}

class myHelloWorld implements HelloWorldService{
	public String name;
	
	public void sayHello(String name) {
		System.out.println("Hello "+name+".");
	}
	
	public void setName(String name) {
		this.name = name;
	}
	
	public String getName() {
		return name;
	}
	
	
}

@Target(ElementType.TYPE)
@Retention(RetentionPolicy.RUNTIME)
@Documented
@interface ClassAnnotation{
	public String value();
}

@Target(ElementType.METHOD)
@Retention(RetentionPolicy.RUNTIME)
@Documented
@interface MethodAnnotation{
	public String MethodName();
	public String ReturnType();
}

@Target(ElementType.FIELD)
@Retention(RetentionPolicy.RUNTIME)
@Documented
@interface FieldAnnotation{
	public String value();
}

@Target(ElementType.PARAMETER)
@Retention(RetentionPolicy.RUNTIME)
@Documented
@interface ParameterAnnotation{
	public String value();
}

@ClassAnnotation("Annotation on Class")
class myDemoClass
{
	@MethodAnnotation(MethodName="printInfo",ReturnType="void")
	public void printInfo(String Info)
	{
		System.out.println(Info);
	}
	
	@MethodAnnotation(MethodName="printError",ReturnType="void")
	public void printError(@ParameterAnnotation("Annotation on parameter")String err)
	{
		System.err.println(err);
	}
	
	@FieldAnnotation("Annotation on Field")
	public int count;
	
}

interface AOPInterceptor{
	public void before(Method method,Object[] args);
	public void after(Method method,Object[] args);
	public void afterThrowing(Method method,Object[] args);
	public void afterFinally(Method method,Object[] args);
}

class DynamicProxyInvocationHandler implements InvocationHandler
{
	private Object target;
	private AOPInterceptor interceptor;
	
	public DynamicProxyInvocationHandler(Object target,AOPInterceptor interceptor) {
		this.target=target;
		this.interceptor=interceptor;
	}

	@Override
	public Object invoke(Object proxy, Method method, Object[] args)
			throws Throwable {
		try {
			interceptor.before(method, args);
			Object returnValue = method.invoke(target, args);
			interceptor.after(method, args);
			return returnValue;
			
			
		} catch (Throwable t) {
			interceptor.afterThrowing(method, args);
			throw t;
		}
		finally{
			interceptor.afterFinally(method, args);
		}
		
	}}

