package dp.flyWeight;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.Vector;

public class ConnectionPool {
	private Vector<Connection> pool;
	private String url= "jdbc:mysql://localhost:3306/test";  
	private String username = "root";
	private String password = "root";
	private String driverClassname = "com.mysql.jdbc.Driver";  
	
	private int poolSize=100;
	private static ConnectionPool instance = null;
	
	Connection coon = null;
	
	private ConnectionPool() {
		pool = new Vector<Connection>(poolSize);  
		for(int i=0;i<poolSize;++i)
		{
			try {
				Class.forName(driverClassname);
				coon=DriverManager.getConnection(url,username,password);
				pool.add(coon);
				
			} catch (ClassNotFoundException e) {
				e.printStackTrace();
			}catch (SQLException  e) {
				e.printStackTrace();
			}
		}
	}
	
	public synchronized Connection getConnection() {
		if(poolSize>0)
		{
			Connection conn = pool.get(0); 
			pool.remove(conn); 
			return conn;
		}
		else {
			return null;
		}
	}
	
	public synchronized void release() {
		pool.add(coon);
	}

}
