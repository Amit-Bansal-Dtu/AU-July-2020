import java.util.List;
import java.util.Scanner;
import java.util.LinkedList;

class Producer extends Thread{
	protected BlockQueue q = null;

	public Producer(BlockQueue q) {
		this.q = q;
	}
	public void run(){
		try {
			q.put();
		}
		catch (InterruptedException e) {
			e.printStackTrace();
		}
	}
}

class Consumer extends Thread{
	protected BlockQueue q = null;

	public Consumer(BlockQueue q) {
		this.q = q;
	}
	public void run(){
		try {
			q.take();
		}
		catch (InterruptedException e) {
			e.printStackTrace();
		}
	}
}

class BlockQueue{
	private List<Integer> q = new LinkedList();
	private int max_size;
	public int curr_size;

	public BlockQueue(int size) {
		max_size = size;
		curr_size=0;
	}

	public synchronized void put() throws InterruptedException{
		while(true)
		{
			if(curr_size>1000){
				break;
			}
			if(q.size() == max_size)
			{
				System.out.println("Producer filled the whole queue, now its consumers turn to consume...");
				while(q.size() == max_size) {
					wait();
				}
			}
			if (q.size()==0) {
				notifyAll();
			}
			curr_size++;
			System.out.println("Producer has added task no. "+curr_size );
			q.add(curr_size);
		}
	}

	public synchronized void take() throws InterruptedException {
		while(true)
		{
			if(q.size() == 0)
			{
				System.out.println("Consumer consumed the whole queue, now its producers turn to fill it up...");
				while (q.size() == 0) {
					wait();
				}
			}
			if (q.size()==max_size) {
				notifyAll();
			}
			System.out.println("Consumer Thread "+Thread.currentThread().getName()+" has consumed task no. " +q.remove(0));
		}
	}
}

public class BQ{
    	public static void main(String[] args) {
    		int n, size;
			Scanner s = new Scanner(System.in);
    		System.out.println("Enter the size of the blocking queue: ");
    		size = s.nextInt();
    		System.out.println("Enter the number of consumers: ");
    		n = s.nextInt();
        	BlockQueue q = new BlockQueue(size);
        	System.out.println(q.curr_size);
        	Producer p = new Producer(q);
			new Thread(p).start();

	       	Consumer c[] = new Consumer[n];
			for(int i=0; i<n; i++) {
				c[i] = new Consumer(q);
			}
        	for(int i=0; i<n; i++) {
        		c[i] = new Consumer(q);
				new Thread(c[i]).start();
			}
    	}
}