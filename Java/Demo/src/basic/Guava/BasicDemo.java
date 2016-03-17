package Guava;

import java.util.ArrayList;
import java.util.List;

import com.google.common.base.Optional;
import com.google.common.base.Preconditions;

public class BasicDemo {

	public static void main(String[] args) throws Exception {
		// FooAvoidingNull();
		FooPreCondition();

	}

	private static void FooAvoidingNull() {

		Optional<Integer> possible = Optional.of(5);
		System.out.println(possible.get());
		System.out.println(possible.isPresent());

		String aString = null;
		// Optional<String> possibleStr = Optional.of(aString);
		Optional<String> possibleStr = Optional.fromNullable(aString);
		System.out.println(possibleStr.or("EmptyString"));
		System.out.println(possibleStr.isPresent());
		System.out.println(possibleStr.absent());
	}

	private static void FooPreCondition() throws Exception {
		String neme = "";
		int age = 0;
/*		Preconditions.checkNotNull(neme, "neme为null");
		Preconditions.checkArgument(neme.length() > 0, "neme为\'\'");
		Preconditions.checkArgument(age > 0, "age 必须大于0");
		System.out.println("a person age:" + age + ",neme:" + neme);*/

		getPersonByPrecondition(8, "peida");

		try {
			getPersonByPrecondition(-9, "peida");
		} catch (Exception e) {
			System.out.println(e.getMessage());
		}

		try {
			getPersonByPrecondition(8, "");
		} catch (Exception e) {
			System.out.println(e.getMessage());
		}

		try {
			getPersonByPrecondition(8, null);
		} catch (Exception e) {
			System.out.println(e.getMessage());
		}

		List<Integer> intList = new ArrayList<Integer>();
		for (int i = 0; i < 10; i++) {
			try {
				checkState(intList, 9);
				intList.add(i);
			} catch (Exception e) {
				System.out.println(e.getMessage());
			}

		}

		try {
			checkPositionIndex(intList, 3);
		} catch (Exception e) {
			System.out.println(e.getMessage());
		}

		try {
			checkPositionIndex(intList, 13);
		} catch (Exception e) {
			System.out.println(e.getMessage());
		}

		try {
			checkPositionIndexes(intList, 3, 7);
		} catch (Exception e) {
			System.out.println(e.getMessage());
		}

		try {
			checkPositionIndexes(intList, 3, 17);
		} catch (Exception e) {
			System.out.println(e.getMessage());
		}

		try {
			checkPositionIndexes(intList, 13, 17);
		} catch (Exception e) {
			System.out.println(e.getMessage());
		}

		try {
			checkElementIndex(intList, 6);
		} catch (Exception e) {
			System.out.println(e.getMessage());
		}

		try {
			checkElementIndex(intList, 16);
		} catch (Exception e) {
			System.out.println(e.getMessage());
		}

	}
	
    public static void getPersonByPrecondition(int age,String neme)throws Exception{
        Preconditions.checkNotNull(neme, "neme为null");
        Preconditions.checkArgument(neme.length()>0, "neme为\'\'");
        Preconditions.checkArgument(age>0, "age 必须大于0");
        System.out.println("a person age:"+age+",neme:"+neme);
         
    }

	public static void checkState(List<Integer> intList, int index)
			throws Exception {
		// 表达式为true不抛异常
		Preconditions.checkState(intList.size() < index, " intList size 不能大于"
				+ index);
	}

	public static void checkPositionIndex(List<Integer> intList, int index)
			throws Exception {
		Preconditions.checkPositionIndex(index, intList.size(), "index "
				+ index + " 不在 list中， List size为：" + intList.size());
	}

	public static void checkPositionIndexes(List<Integer> intList, int start,
			int end) throws Exception {
		Preconditions.checkPositionIndexes(start, end, intList.size());
	}

	public static void checkElementIndex(List<Integer> intList, int index)
			throws Exception {
		Preconditions.checkElementIndex(index, intList.size(), "index 为 "
				+ index + " 不在 list中， List size为： " + intList.size());
	}

}
