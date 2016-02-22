package basic.thread;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.concurrent.Callable;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.FutureTask;


public class CallableTest {

	public static void main(String[] args) throws InterruptedException, ExecutionException {
		new CallableTest().exec();

	}
	
	void exec() throws InterruptedException, ExecutionException{
		List<FutureTask<Integer>> futureTasks = new ArrayList<FutureTask<Integer>>();
		ExecutorService executorService = Executors.newFixedThreadPool(10);
		long start = System.currentTimeMillis();
		
		Callable<Integer> callable  = new Callable<Integer>(){

			@Override
			public Integer call() throws Exception {
				Integer res = new Random().nextInt(100);
				Thread.sleep(1000);
				System.out.println("Done: "+res);
				return res;
			}
			};
			
		for(int i=0;i<10;++i)
		{
			FutureTask<Integer> futureTask = new FutureTask<Integer>(callable);
			futureTasks.add(futureTask);
			executorService.submit(futureTask);
		}
		
		int count = 0;
		
		for(FutureTask<Integer> futureTask : futureTasks){
			count+= futureTask.get();
		}
		
		long end = System.currentTimeMillis();
		System.out.println(count);
		System.out.println(end-start);
		executorService.shutdown();
	}

}
