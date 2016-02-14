package basic;

import java.util.Scanner;

import basic.event.*;

public class EventTest {

	public static void main(String[] args) {
		System.out.println("START");  
		Scanner scan = new Scanner(System.in);  
		Ask ask = new Ask();  
		 ask.addListener(new Listener(){  
			 public void listen(AskEvent ae) { 
				 if(ae.getName().equals("a")) System.out.println(ae.getName() + "good man");  
				 else System.out.println(ae.getName() + "bad man");  
			 }
		 });
		 
		 while(true){
	            System.out.print("input name:");
	            final String name = scan.nextLine();
	            if(name.equals("exit")) break;
	            if(name.equals("print")) {
	                ask.setFlag(true);
	                continue;
	            }
	            ask.addName(name);
	        }
	        System.out.println("OVER");
	    }
	}
