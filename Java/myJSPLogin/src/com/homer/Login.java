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
			request.getSession().setMaxInactiveInterval(30*60);		//  ����sessionʧЧʱ�䣨timeout������λΪ��  
			request.getSession().setAttribute("userinfo", USERNAME);		//�û�����������ȷ�������¼��Ϣ(���session��jsp��ҳ���в�ͬ)
			response.sendRedirect("page111.jsp");
		} else {
			response.sendRedirect("userlogin.html");			// �û��������������ת����¼����  
		}
	}
}
