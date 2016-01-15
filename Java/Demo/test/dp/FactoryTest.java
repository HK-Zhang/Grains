package dp;

import dp.factory.*;

public class FactoryTest {

	public static void main(String[] args) {
		SendFactory sFactory = new SendFactory();
		ISender sender = sFactory.produceSender("mail");
		sender.Send();
		
		ISender sender2 = sFactory.produceSMSSender();
		sender2.Send();
		
		ISender sender3 = SendFactory.produceMailSender();
		sender3.Send();

	}

}
