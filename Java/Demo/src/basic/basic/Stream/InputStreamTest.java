package basic.Stream;

import java.io.BufferedReader;
import java.io.FileReader;

public class InputStreamTest {

	public static void main(String[] args) throws Exception {
		 System.out.println(read("src/basic/basic/Stream/InputStreamTest.java"));  

	}
	
	public static String read(String fileName) throws Exception {
		BufferedReader br = new BufferedReader(new FileReader(fileName));
		String s;
		StringBuffer sBuffer=new StringBuffer();
		while ((s=br.readLine())!=null) {
			sBuffer.append(s+"\n");
		}
		br.close();
		return sBuffer.toString();
	}

}
