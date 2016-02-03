package basic.Stream;

import java.util.Scanner;

public class StandardIO2 {

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		
		String s;
		while((s = scanner.next()) != null && s.length() != 0){ 
			 System.out.println(s);
	}
		
		scanner.close();

}
}
