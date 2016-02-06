package basic.collection;

import java.util.Set;
import java.util.SortedMap;
import java.util.TreeMap;

public class SortMapTest {

	public static void main(String[] args) {
		Foo1();

	}
	
	public static void Foo1() {
		SortedMap<String, Integer> map = new TreeMap<String, Integer>();
		map.put("A", 1);
		map.put("B", 2);
		map.put("C", 3);
		map.put("D", 4);
		map.put("E", 5);
		
		Set<String> keys = map.keySet();
		for(String s:keys)
		{
			System.out.println(map.get(s)+" ");
		}
	}

}
