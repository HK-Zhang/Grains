package basic.event;

import java.util.EventObject;

public class AskEvent extends EventObject {

	private static final long serialVersionUID = 1L;  
	private Object Evnetsource;  
	private String name; 
	
	
	public Object getEvnetsource() {
		return Evnetsource;
	}
	
	public String getName() {
		return name;
	}
	 
	public AskEvent(Object source,String name) {
		super(source);
		Evnetsource = source;
		this.name = name;
	}

}
