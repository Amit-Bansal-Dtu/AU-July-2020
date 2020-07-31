import org.dom4j.*;
import java.sql.*;
import java.io.File;
import java.util.*;
import org.dom4j.io.SAXReader;

public class JdbcMysql {
    // JDBC driver name and database URL
    static final String JDBC_DRIVER = "com.mysql.cj.jdbc.Driver";
    static final String DB_URL = "jdbc:mysql://localhost:3306/school";

    //  Database credentials
    static final String USER = "root";
    static final String PASS = "Sumit@1006762";

    public static void main(String[] args) {
        Connection conn = null;
        Statement stmt = null;
        try {
            //STEP 2: Register JDBC driver
            Class.forName("com.mysql.cj.jdbc.Driver");

            //STEP 3: Open a connection
            System.out.println("Connecting to school database...\n");
            conn = DriverManager.getConnection(DB_URL, USER, PASS);

            //STEP 4: Execute a query
            System.out.println("Creating Table Student...\n");
            stmt = conn.createStatement();
            String sql;
            sql = "CREATE TABLE student( id integer primary key,name varchar(50) not null,surname varchar(20) not null,gender varchar(20) not null, marks float not null)";
            stmt.execute(sql);

            String f_name="", m_name="", l_name="", gender="";
            int id=0;
            float marks=0f;

            File f = new File("input.txt");
            SAXReader s = new SAXReader();
            Document d = s.read(f);

            List<Node> nodes = d.selectNodes("/class/student");
            for(Node node: nodes){
                id = Integer.parseInt(node.valueOf("@rollno"));
                f_name = node.selectSingleNode("name/firstname").getText();
                m_name = node.selectSingleNode("name/middlename").getText();
                l_name = node.selectSingleNode("name/lastname").getText();
                gender = node.selectSingleNode("gender").getText();
                marks = Float.parseFloat(node.selectSingleNode("marks").getText());

                PreparedStatement ps = conn.prepareStatement("insert into student values (?,?,?,?,?)");
                ps.setInt(1, id);
                ps.setString(2, f_name+ " "+ m_name);
                ps.setString(3, l_name);
                ps.setString(4, gender);
                ps.setFloat(5, marks);
                if(ps.executeUpdate()>0)
                    System.out.println("Data inserted into student table\n");
                else
                    System.out.println("Insertion Failed");
            }

            stmt = conn.createStatement();
            ResultSet DataSet =  stmt.executeQuery("select * from student");
            while (DataSet.next()) {
                System.out.print(DataSet.getInt("id")+"\t");
                System.out.print(DataSet.getString("Name")+"\t");
                System.out.print(DataSet.getString("Surname")+"\t");
                System.out.print(DataSet.getString("Gender")+"\t");
                System.out.println(DataSet.getFloat("Marks")+"\t");
            }
            conn.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
