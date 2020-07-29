import java.util.*; 
import java.util.stream.*;
import java.io.File;
import java.io.IOException;
import java.nio.Buffer;
import java.nio.ByteBuffer;
import java.nio.file.FileSystem;
import java.nio.file.LinkOption;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.io.IOException;
import java.nio.file.Files;
import java.util.List;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class FileCount{
	static int count_files=0;
	static int count_directories = 0;
	public static void main(String[]args){
		Path path= Paths.get("C:/Users/Amit Bansal/Desktop/Job_placement/Accolite_University/adv_java_assgn");
		try (Stream<Path> paths = Files.walk(path)) {
    			List<String> result = paths.filter(Files::isRegularFile)
			.map(x -> x.toString()).collect(Collectors.toList());
			result.forEach(string->count_files+=1);
			System.out.println("Total number of files: " +count_files);

		} catch(Exception e){
      			e.printStackTrace();
   		}
		try (Stream<Path> paths = Files.walk(path)) {
    			List<String> result = paths.filter(Files::isDirectory)
			.map(x -> x.toString()).collect(Collectors.toList());
			result.forEach(string->count_directories+=1);
			System.out.println("Total number of directories: " +count_directories);

		} catch(Exception e){
      			e.printStackTrace();
   		}
	}
}