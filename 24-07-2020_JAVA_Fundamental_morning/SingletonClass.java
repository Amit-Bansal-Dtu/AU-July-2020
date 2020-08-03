import java.util.*;
class Singleton{
	private static Singleton one_instance = null;

	public int x;

	private Singleton(){
		x = 10;	
	}
	
	public static Singleton getInstance(){
		if(one_instance==null){
			//making it thread safe
			synchronized (Singleton.class) {
				//dual checking
				if(one_instance==null) {
					one_instance = new Singleton();
				}
			}
		}
		return one_instance;
	}
}

public class SingletonClass{
	public static void main(String[]args){
		Singleton a = Singleton.getInstance();
		Singleton b = Singleton.getInstance();
		Singleton c = Singleton.getInstance();
		System.out.println(a.x);
		System.out.println(b.x);
		System.out.println(c.x);
		a.x=5;
		System.out.println(a.x);
		System.out.println(b.x);
		System.out.println(c.x);
		a.getInstance();
		System.out.println(a.x);
		b.x=15;
		System.out.println(a.x);
		System.out.println(b.x);
		System.out.println(c.x);
	}
}