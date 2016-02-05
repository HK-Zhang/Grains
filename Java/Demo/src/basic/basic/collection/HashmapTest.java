package basic.collection;

import java.util.HashMap;
import java.util.Map;
import java.util.Set;

public class HashmapTest {

	public static void main(String[] args) {
		//Foo1();
		Foo2();

	}
	
	public static void Foo1() {
		Map<String, Integer> map = new HashMap<String, Integer>();
		System.out.println("Hashmap's initial value:"+map.size());
		System.out.println("Is hashmap empty:"+(map.isEmpty()?"Yes":"No"));
		
		map.put("A", 1);
		map.put("B", 2);
		map.put("C", 3);
		
		System.out.println("Hashmap's initial value:"+map.size());
		System.out.println("Is hashmap empty:"+(map.isEmpty()?"Yes":"No"));
		
		Set<String> set = map.keySet();
		for(String s:set){
			System.out.println(s+" "+map.get(s)+" hashcode: "+s.hashCode());
		}
		
		System.out.println(map.containsKey("A"));
		System.out.println(map.containsValue(1));
		
		System.out.println(map.hashCode());
		
	}
	
	public static void Foo2() {
		int [] a = {2,3,2,2,1,4,2,2,2,7,9,6,2,2,3,1,0};  
		HashMap<Integer,Integer> map = new HashMap<Integer,Integer>();
		
		for(int i=0;i<a.length;++i)
		{
			if(map.containsKey(a[i]))
			{
				int tmp=map.get(a[i]);
				tmp+=1;
				map.put(a[i], tmp);
			}
			else{
				map.put(a[i], 1);
			}
		}
		
		Set<Integer> set = map.keySet();
		for(Integer s:set){
			if(map.get(s)>=a.length/2)
			{
				System.out.println(s);
			}
		}
	}

}
