package basic.collection;

import java.util.LinkedList;

public class LinkedlistTest {

	public static void main(String[] args) {
		Foo1();

	}
	
	public static void Foo1() {
		
		LinkedList<Integer> list = new LinkedList<Integer>();
		System.out.println(list.size());
		
		list.add(222);
		list.add(111);
		list.add(0);
		list.add(3333);
		list.add(8888);
		
		System.out.println(list.size());
		
		for(Integer i:list)
		{
			System.out.println(i);
		}
		
		System.out.println("The first value"+list.getFirst());
		System.out.println("The last value"+list.getLast());
	}

}
