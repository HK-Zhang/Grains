package dp.builder;

import java.util.ArrayList;
import java.util.List;

import dp.factory.*;

public class Builder {
	private List<ISender> SenderLst = new ArrayList<ISender>();
	
	public void produceMailSender(int count) {
		for(int i=0;i<count;++i){
			SenderLst.add(new MailSender());
		}
	}
	
	public void produceSmsSender(int count) {
		for(int i=0;i<count;++i){
			SenderLst.add(new SMSSender());
		}
	}
}
