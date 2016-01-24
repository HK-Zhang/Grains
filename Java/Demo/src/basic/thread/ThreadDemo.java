package basic.thread;

public class ThreadDemo {
	static int a=0;
	
	public static synchronized void assignValue() throws InterruptedException {
		a=1;
		Thread.sleep(3000);
	}
	
    public static class ChangeT implements Runnable{
       
        public void run() {
        	try {
				assignValue();
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
        }
    }
	
	public static void testSynchronized() throws InterruptedException {
		 new Thread(new ChangeT()).start();
		 System.out.println(a);
		 Thread.sleep(1000);
		 System.out.println(a);
		 Thread.sleep(2000);
		 System.out.println(a);
		
	}

}
