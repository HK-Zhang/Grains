package basic.thread;

public class ThreadTest {
	private int i =0;
	private Object object = new Object();

	public static void main(String[] args) {
		//Foo1();
		//Foo2();
		//Foo3();
		//Foo4();
		Foo5();
	}
	
	private static void Foo1()
	{
		ThreadTest test = new ThreadTest();
		MyThread thread1 = test.new MyThread();
		MyThread thread2 = test.new MyThread();
		thread1.start();
		thread2.start();
	}
	
	private static void Foo2()
	{
		 System.out.println("enter thread:"+Thread.currentThread().getName());
		 ThreadTest test = new ThreadTest();
		 MyThread thread1 = test.new MyThread();
		 thread1.start();
		 try {
			 System.out.println("Thread "+Thread.currentThread().getName()+" wait");
			 thread1.join();
			 System.out.println("Thread "+Thread.currentThread().getName()+" Continue");
			
		} catch (InterruptedException  e) {
			e.printStackTrace();
		}
	}
	
	private static void Foo3() {
		ThreadTest test = new ThreadTest();
		MyThreadB thread = test.new MyThreadB();
		thread.start();
		try {
			thread.currentThread().sleep(2000);
			
		} catch (InterruptedException e) {
			// TODO: handle exception
		}
		thread.interrupt();
	}
	
	private static void Foo4() {
		ThreadTest test = new ThreadTest();
		MyThreadC thread = test.new MyThreadC();
		thread.start();
		try {
			thread.currentThread().sleep(2000);
			
		} catch (InterruptedException e) {
			// TODO: handle exception
		}
		thread.interrupt();
	}
	
	private static void Foo5() {
		ThreadTest test = new ThreadTest();
		MyThreadD thread = test.new MyThreadD();
		thread.start();
		try {
			thread.currentThread().sleep(2000);
			
		} catch (InterruptedException e) {
			// TODO: handle exception
		}
		thread.setStop();
		System.out.println("Stop");
	}
	
	class MyThread extends Thread{
		@Override
		public void run() {
			synchronized (object) {
				++i;
				System.out.println("i:"+i);
				try {
					System.out.println("Thread "+Thread.currentThread().getName()+" is sleeping");
					Thread.currentThread().sleep(5000);
				} catch (InterruptedException e) {
					// TODO: handle exception
				}
				
				System.out.println("Thread "+Thread.currentThread().getName()+" wake up");
				++i;
				System.out.println("i:"+i);
			}
		}
		
	}
	
	class MyThreadB extends Thread{
		@Override
		public void run() {
			try {
				System.out.println("Sleep");
				Thread.currentThread().sleep(5000);
				System.out.println("WakeUp");
			} catch (InterruptedException  e) {
				System.out.println("Iterruppetd");
			}
			
			System.out.println("Completed");
		}
	}
	
	class MyThreadC extends Thread{
		@Override
		public void run() {
			int i = 0;
			while(!isInterrupted() && i<Integer.MAX_VALUE)
			{
				System.out.println(i);
				++i;
			}
		}
	}
	
	class MyThreadD extends Thread{
		private volatile boolean isStop = false;
		@Override
		public void run() {
			int i = 0;
			while(!isStop)
			{
				System.out.println(i);
				++i;
			}
			
		}
		
		public void setStop() {
			isStop=true;
		}
	}

}
