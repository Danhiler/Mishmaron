<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print_Mode_list.aspx.cs" Inherits="Print_Mode_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>רשימת עובדים</title>
      <style type="text/css">
table.sample {
	border-width: 2px;

	border-style: solid;
	border-color: gray;
	border-collapse: collapse;
}
table.sample th {
	border-width: 1px;
	padding: 1px;
	border-style: dotted;
	border-color: gray;
}
table.sample td {
	border-width: 1px;
	padding: 1px;
	border-style: dotted;
	border-color: gray;
}
</style>
<link rel="shortcut icon" type="image/x-icon" href="/Pictures/favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
    <div dir="rtl" align="center" >
    <h1>
    <%=Session["Cname"] %>
    </h1>
    <h2>
    רשימת עובדים - <%=date%>
    </h2>
       <% PrintList();  %>
       <a href="javascript:window.print()">הדפס</a>
    
    </div>
    </form>
</body>
</html>
