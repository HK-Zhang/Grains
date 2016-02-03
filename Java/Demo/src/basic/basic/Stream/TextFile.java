package basic.Stream;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintWriter;
import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;

public class TextFile extends ArrayList<String> {

	private static final long serialVersionUID = -1942855619975438512L;  
	
	public TextFile(String fileName, String splitter) {
		super(Arrays.asList(read(fileName).split(splitter)));
		if(get(0).equals(""))
			remove(0);
	}
	
	public TextFile(String fileName) {
		this(fileName, "\n");
	}
	
	public static String read(String filename) {
		StringBuilder sb = new StringBuilder();
		
		try {
			BufferedReader in = new BufferedReader(new FileReader(new File(filename).getAbsoluteFile()));
			
			String s;
			
			try
			{
				while((s=in.readLine())!=null)
				{
					sb.append(s);
					sb.append("\n");
				}
			}
			finally
			{
				in.close();
			}
			
			
		} catch (IOException e) {  
			throw new RuntimeException(e);
		}
		
		return sb.toString();
		
	}
	
	public static void write(String fileName,String text) {
		try {
			PrintWriter out = new PrintWriter(new File(fileName).getAbsoluteFile());
			
			try {
				out.print(text);
			} finally {
				out.close();
			}
			
		} catch (IOException e) {
			throw new RuntimeException(e);
		}
	}
	
	public void write(String fileName) {
		try {
			PrintWriter out = new PrintWriter(new File(fileName).getAbsoluteFile());
			
			try {
				for (String item : this)  
					out.println(item);
			} finally {
				out.close();
			}
			
		} catch (IOException e) {
			throw new RuntimeException(e);
		}
	}
	
	public static void main(String[] args) {
		 System.out.println(read("data.d")); 
		 write("out.d", "helloworld\negg"); 
		 TextFile tf = new TextFile("data.d"); 

	}
	
	

}
