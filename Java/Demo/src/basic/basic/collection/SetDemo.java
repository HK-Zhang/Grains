package basic.collection;

import java.util.HashSet;
import java.util.Set;

public class SetDemo {

	public static void main(String[] args) {
		Set<String> set = new HashSet<String>();
		String a = "hello";
		String b = "hello";
		String s = new String("hello");  
		String s1 = new String("hello");  
		
		set.add(a);
		set.add(b);
		set.add(s);
		set.add(s1);
		
		System.out.println("szie:"+set.size());
		
		for(String ss:set){
			System.out.println(s);
		}

	}

}
