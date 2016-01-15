package dp.factory;

public class SendFactory {

	public ISender produceSender(String type) {
		if("mail".equals(type)){
			return new MailSender();
		}
		else if ("sms".equals(type)) {
			return new SMSSender();
		}
		else {
			System.out.println("Please input correct type");
			return null;
		}
		
	}
	
	public static ISender produceMailSender() {
		return new MailSender();
	}
	
	public ISender produceSMSSender() {
		return new SMSSender();
	}
}
