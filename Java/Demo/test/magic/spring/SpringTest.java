package magic.spring;

import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import magic.spring.dao.*;

public class SpringTest {

	@SuppressWarnings("resource") 
	public static void main(String[] args) {
		ApplicationContext atx = new ClassPathXmlApplicationContext("classpath:beans.xml");
		//ApplicationContext atx = new ClassPathXmlApplicationContext("file:D:/TWApp/Demo/beans.xml");
		UserDao userDao = (UserDao)atx.getBean("userDao");  
		userDao.add();  

	}

}
