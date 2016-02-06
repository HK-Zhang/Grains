package basic.collection;

import java.util.LinkedList;
import java.util.List;

public class LoopTest {

	public static void main(String[] args) {
		List<String> list = new LinkedList<String>();
		
		list.add("A");
		list.add("B");
		list.add("C");
		
		for(int i=0;i<list.size();++i)
		{
			list.remove(i);
			--i;
		}
		
		for(String item:list)
		{
			System.out.println(item);
		}
		

	}

}
