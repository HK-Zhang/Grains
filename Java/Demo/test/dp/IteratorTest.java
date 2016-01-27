package dp;

import dp.iterator.*;
public class IteratorTest {

	public static void main(String[] args) {
		ICollection collection = new myCollection();
		IIterator iterator = collection.iterator();
		
		while (iterator.hasNext()) {
			System.out.println(iterator.next());
		}

	}

}
