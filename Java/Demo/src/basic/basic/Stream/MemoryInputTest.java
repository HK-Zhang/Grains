package basic.Stream;

import java.io.StringReader;

public class MemoryInputTest {

	public static void main(String[] args) throws Exception {
		StringReader sReader = new StringReader(InputStreamTest.read("src/basic/basic/Stream/InputStreamTest.java"));

		int c;
		
		while ((c=sReader.read())!=-1) {
			System.out.println((char) c);  
		}
		
	}

}
