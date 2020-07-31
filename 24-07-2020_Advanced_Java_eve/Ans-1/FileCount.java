
import java.util.*;
import java.util.stream.*;
import java.io.File;

// Recursive Function to get whole directories, subdirectories and files counts....

class GetCount{
    public void get(String path){
        int count_f = 0;
        int count_d = 0;
        File directory=new File(path);
        String[] paths = directory.list();
        for(String p: paths){
            File subdirec = new File(path+"\\"+p);
            if(subdirec.isDirectory()){
                count_d+=1;
                get(path+"\\"+p);
            }
            else{
                count_f+=1;
            }
        }
        System.out.println("{ "+path+" }: ==>  contains "+count_f+" files and "+count_d+" directories");
    }
}

public class FileCount{
	static int count_files=0;
	static int count_directories = 0;
	public static void main(String[]args) {
        String path = "C:\\Users\\Amit Bansal\\Desktop\\Job_placement\\Accolite_University\\adv_java_assgn\\Ans-1";
        GetCount G = new GetCount();
        G.get(path);
	}
}
