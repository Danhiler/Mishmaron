<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print_boxs_workers.aspx.cs" Inherits="Print_boxs_workers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>דף פרטים לעובדים</title>
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
<body dir="rtl">

    <div>
    <%PrintList(); %>
    <center>
       <a href="javascript:window.print()">הדפס</a>
       </center>
    </div>

</body>
</html>
