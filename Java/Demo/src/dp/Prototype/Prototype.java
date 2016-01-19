package dp.Prototype;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;

public class Prototype implements Cloneable, Serializable {

	private static final long serialVersionUID = 1L;  
	private String str;
	private SerializableObject obj;
	
	public String getString() {
		return str;
	}
	
	public void setString(String string) {
		this.str=string;
	}
	
	public SerializableObject getObject() {
		return obj;
	}
	
	public void setObject(SerializableObject sobj) {
		obj=sobj;
	}
	
	public Object clone() throws CloneNotSupportedException {
		Prototype proto = (Prototype)super.clone();
		return proto;
	}
	
	public Object deepClone() throws IOException,ClassNotFoundException {
		ByteArrayOutputStream bos = new ByteArrayOutputStream();
		ObjectOutputStream oos = new ObjectOutputStream(bos);
		oos.writeObject(this);
		
		ByteArrayInputStream bis = new ByteArrayInputStream(bos.toByteArray());
		ObjectInputStream ois = new ObjectInputStream(bis);
		return ois.readObject();
	}
}

class SerializableObject implements Serializable {  
    private static final long serialVersionUID = 1L;  
}  
