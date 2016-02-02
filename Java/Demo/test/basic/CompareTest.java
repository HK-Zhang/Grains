package basic;

import java.util.Arrays;

import basic.compare.*;

public class CompareTest {

	public static void main(String[] args) {
		String[] array  = new String[]{ "一二", "三", "二" }; 
		Arrays.sort(array,new SampleComparator());
		
		for(int i=0;i<array.length;++i)
		{
			System.out.println(array[i]);
		}
		
		User[] users = new User[]{new User("a", 30),new User("b", 29)};
		Arrays.sort(users);
		
		for(int i=0;i<users.length;++i)
		{
			User user = users[i];
			System.out.println(user.getId()+" "+user.getAge());
		}
	

	}

}
