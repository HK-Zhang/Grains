<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>login.jsp</title>
</head>

<%
	String USERNAME = "admin";
	String USERPWD = "123456";
	
	request.setCharacterEncoding("utf8");

	String userName = request.getParameter("username").trim();
	String userPwd = request.getParameter("userpwd").trim();
	
	if(userName == null || userPwd == null){
		response.sendRedirect("userlogin.html");
		return;
	}
	
	if(userName.equals(USERNAME) && userPwd.equals(USERPWD)) {
		session.setMaxInactiveInterval(30*60);			// 设置session失效时间（timeout），单位为秒
		session.setAttribute("userinfo", USERNAME);		// 用户名和密码正确，保存登录信息
		response.sendRedirect("page111.jsp");
	} else {
		response.sendRedirect("userlogin.html");		// 用户名和密码错误，跳转到登录界面
	}
%>

<body>



</body>
</html>