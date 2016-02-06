package basic.collection;

import java.util.Map;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class CollectionsTest {

	public static void main(String[] args) {
		//SingletonTest();
		//SearchTest();
		//SortTest();
		RotateTest();

	}
	
	public static void SingletonTest() {
		Map<Integer, Integer> map=Collections.singletonMap(1, 1);
		System.out.println(map.size());
		
	}
	
	public static void SearchTest() {
		List<Integer> list = new ArrayList<Integer>();
		list.add(1);
		list.add(2);
		
		for(Integer i:list)
		{
			System.out.println(i);
		}
		
		int max=Collections.max(list);
		System.out.println("max is: "+max);
		
		Collections.fill(list, 6);
		
		System.out.println("After replacement");
		for(Integer i:list)
		{
			System.out.println(i);
		}
		
		int count = Collections.frequency(list, 6);
		System.out.println("count of 6:"+count);
		
	}
	
	public static void SortTest() {
		List<Integer> list = new ArrayList<Integer>();
		list.add(5);
		list.add(2);
		list.add(1);
		list.add(9);
		list.add(0);
		
		System.out.println("before sorting");
		for(Integer i:list)
		{
			System.out.println(i);
		}
		
		Collections.sort(list);
		
		System.out.println("after sorting");
		for(Integer i:list)
		{
			System.out.println(i);
		}
		
	}
	
	public static void RotateTest() {
		List<Integer> list = new ArrayList<Integer>();
		list.add(5);
		list.add(2);
		list.add(1);
		list.add(9);
		list.add(0);
		
		System.out.println("before rotate");
		for(Integer i:list)
		{
			System.out.println(i);
		}
		
		Collections.rotate(list,-1);
		
		System.out.println("after rotate");
		for(Integer i:list)
		{
			System.out.println(i);
		}
		
	}

}
