import java.util.*;
import java.util.HashMap; 

public class CountString{
	public static void main(String[]args){
		Scanner s = new Scanner(System.in);
		int n = s.nextInt();
		s.nextLine();
		ArrayList<String>arr = new ArrayList<String>(n);
		HashMap<String, Integer> map = new HashMap<String, Integer>();
		for(int i=0; i<n; i++){
			String str = s.nextLine();
			arr.add(str);
			if(map.containsKey(str)){
				int val = map.get(str);
				map.remove(str);
				map.put(str, val+1);
			}
			else{
				map.put(str, 1);
			}
		}
		map.forEach((K,V)->{System.out.println(K+": "+V);});
	}
}