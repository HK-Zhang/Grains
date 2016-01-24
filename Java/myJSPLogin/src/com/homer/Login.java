package com.homer;

import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.xml.ws.RespectBinding;
import javax.xml.ws.Response;

public class Login extends HttpServlet {
	private static final long serialVersionUID = 1L;
	
	private final static String USERNAME = "admin";
	private final static String USERPWD = "123456";
	
	@Override
	protected void doGet(HttpServletRequest request, HttpServletResponse response) {
	}

	@Override
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		request.setCharacterEncoding("utf-8");
		
		String userName = request.getParameter("username").trim();
		String userPwd = request.getParameter("userpwd").trim();
		
		if(userName == null || userPwd == null) {
			response.sendRedirect("userlogin.html");
		}
		
		if(userName.equals(USERNAME) && userPwd.equals(USERPWD)) {
			request.getSession().setMaxInactiveInterval(30*60);		//  设置session失效时间（timeout），单位为秒  
			request.getSession().setAttribute("userinfo", USERNAME);		//用户名和密码正确，保存登录信息(获得session与jsp网页稍有不同)
			response.sendRedirect("page111.jsp");
		} else {
			response.sendRedirect("userlogin.html");			// 用户名和密码错误，跳转到登录界面  
		}
	}
}
