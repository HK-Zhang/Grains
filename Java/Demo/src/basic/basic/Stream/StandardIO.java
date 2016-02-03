package basic.Stream;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class StandardIO {

	public static void main(String[] args) throws IOException {
		BufferedReader bReader = new BufferedReader(new InputStreamReader(System.in));
		String s;
		 while ((s = bReader.readLine()) != null && s.length() != 0) 
			 System.out.println(s);

	}

}
