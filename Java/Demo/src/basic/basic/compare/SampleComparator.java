package basic.compare;

import java.util.Comparator;

public class SampleComparator implements Comparator {

	@Override
	public int compare(Object o1, Object o2) {
		return toInt(o1)-toInt(o2);
	}
	
	private int toInt(Object o) {
		String s = (String)o;
		s=s.replaceAll("一", "1");
		s=s.replaceAll("二", "2");
		s=s.replaceAll("三", "3");
		
		return Integer.parseInt(s);
	}

}
