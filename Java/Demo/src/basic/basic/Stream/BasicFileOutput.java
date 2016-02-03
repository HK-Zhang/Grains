package basic.Stream;

import java.io.BufferedReader;
import java.io.FileWriter;
import java.io.PrintWriter;
import java.io.StringReader;



public class BasicFileOutput {

	static String file = "basie.out";
	
	public static void main(String[] args) throws Exception {
		BufferedReader in = new BufferedReader(new StringReader(InputStreamTest.read("src/basic/basic/Stream/InputStreamTest.java")));
		PrintWriter out = new PrintWriter(new FileWriter(file));
		
		int lineCount=1;
		String s;
		
		while ((s=in.readLine())!=null) {
			out.println(lineCount++ + ": " + s); 
		}
		
		out.close();
		System.out.println(InputStreamTest.read(file));  
		

	}

}
 
