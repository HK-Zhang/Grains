package basic.Stream;

import java.io.BufferedInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;

public class BinaryFile {
	
	public static byte[] read(File file) throws IOException {
		BufferedInputStream bfBufferedInputStream = new BufferedInputStream(new FileInputStream(file));
		
		try {
			byte[] data=new byte[bfBufferedInputStream.available()];
			bfBufferedInputStream.read(data);
			return data;
			
		} finally {
			bfBufferedInputStream.close();
		}
	}
	
	 public static byte[] read(String file) throws IOException {  
		 return read(new File(file).getAbsoluteFile());  
	 }

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}

}
