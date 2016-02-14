package basic.event;

import java.util.ArrayList;
import java.util.List;

public class Ask {

	    private Listener l ;
	    private List<String> names = new ArrayList<String>();
	    
	    public void addListener(Listener l){
	        this.l = l;
	    }
	    
	    public void addName(String name){
	        names.add(name);
	    }
	    
	    public void setFlag(boolean flag){
	        if(flag){
	            if(names.size()==0) System.out.println("ÇëÏÈÊäÈëĞÕÃû£¡£¡£¡");
	            for(int i = 0;i<names.size();i++){
	                l.listen(new AskEvent(this,names.get(i)));
	            }
	            names.clear();
	        }
	    }
	    
}
