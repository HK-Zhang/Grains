package basic.collection;

import java.util.ArrayList;

public class ArraylistTest {

	public static void main(String[] args) {
		//EnsureCapacityTest();
		ListTest();

	}

	public static void EnsureCapacityTest() {
		final int N = 1000000;
		Object obj = new Object();

		ArrayList list = new ArrayList();
		long startTime = System.currentTimeMillis();
		for (int i = 0; i < N; ++i) {
			list.add(obj);
		}
		long endTime = System.currentTimeMillis();

		System.out.println("Not using EnsureCapacity:" + (endTime - startTime)
				+ "ms");

		list = new ArrayList();
		startTime = System.currentTimeMillis();
		list.ensureCapacity(N);

		for (int i = 0; i < N; ++i) {
			list.add(obj);
		}

		endTime = System.currentTimeMillis();

		System.out.println("After using EnsureCapacity:"
				+ (endTime - startTime) + "ms");
	}

	public static void ListTest() {
		ArrayList<String> list = new ArrayList<String>();
		System.out.println("Initial Size:" + list.size());

		list.add("A");
		list.add("B");
		list.add("C");
		list.add("D");
		System.out.println("Current Size:" + list.size());

		list.trimToSize();

		for (String string : list) {
			System.out.println(string);
		}

		list.add(2, "E");

		for (String string : list) {
			System.out.println(string);
		}

		System.out.println("--------------");

		list.clear();

		for (String string : list) {
			System.out.println(string);
		}

		System.out.println("--------------");
	}

}
