package basic.collection;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;


import com.google.common.collect.ImmutableList;
import com.google.common.collect.ImmutableSet;
import com.google.common.collect.ImmutableSortedSet;

public class ImmutableListTest {

	public static void main(String[] args) {
		//Foo1();
		Foo2();

	}
	
	private static void Foo1() {
		List<String> list = new ArrayList<String>();
		list.add("a");
		list.add("b");
		list.add("c");
		System.out.println(list);
		
		List<String> unmodifiableList = Collections.unmodifiableList(list);
		System.out.println(unmodifiableList);
		
		List<String> unmodifiableList2 = Collections.unmodifiableList(Arrays.asList("a","b","c"));
		System.out.println(unmodifiableList2);
		
		 String temp=unmodifiableList.get(1);
		 System.out.println("unmodifiableList [0]："+temp);

		 list.add("baby");
		 System.out.println("list add a item after list:"+list);
		 System.out.println("list add a item after unmodifiableList:"+unmodifiableList);
	        
		 unmodifiableList.add("bb");
		 System.out.println("unmodifiableList add a item after list:"+unmodifiableList);
	     
		 unmodifiableList2.add("cc");
		 System.out.println("unmodifiableList add a item after list:"+unmodifiableList2);  
		
	}
	
	private static void Foo2()
	{
		List<String> list = new ArrayList<String>();
		list.add("a");
		list.add("b");
		list.add("c");
		System.out.println(list);
		
		ImmutableList<String> imList = ImmutableList.copyOf(list);
		System.out.println("imList"+imList);
		
		ImmutableList<String> imOfList = ImmutableList.of("a","b","c");
		System.out.println("imOfList"+imOfList);
		
		ImmutableSortedSet<String> imSet = ImmutableSortedSet.of("a","d","c","b");
		System.out.println("imSet"+imSet);
		
		list.add("baby");
		System.out.println(list);
		System.out.println("imList"+imList);
		
		ImmutableSet<String> ims = ImmutableSet.<String>builder().add("a")
				.add("c")
				.build();
		
		System.out.println(ims);
		
	}
	
	
}
