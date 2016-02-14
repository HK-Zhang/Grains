package basic.event;

import java.util.EventListener;

public interface Listener extends EventListener {
	public void listen(AskEvent ae); 

}
