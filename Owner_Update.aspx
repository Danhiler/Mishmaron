<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Owner_Update.aspx.cs" Inherits="Owner_Update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>עדכון פרטי משתמש</title>
</head>
<body dir="rtl">
<form runat="server">
<asp:TextBox ID="TextBox1" runat="server" Width="300px"></asp:TextBox>
<asp:Button ID="Button1"
    runat="server" Text="HASHMD5" onclick="Button1_Click" />
</form>
   <form name="update" method="post" action="Owner_Updated.aspx">
   <input type="hidden" name="ID" value="<%=ID %>" />
   <input type="hidden" name="Old_UserName" value="<%=UserName %>"  />
   <table>
   <tr>
   <td>
   שם משתמש:
   </td>
   <td colspan="2">
   <input type="text" name="UserName" value="<%=UserName %>" style="width: 300px"  />

   </td>
   </tr>
   <tr>
   <td>
   ססמא:
   </td>
   <td>
   <input type="text" name="PassW" value="<%=PassW %>" />
   </td>
   </tr>
   <tr>
   <td>
   מספר עובדים מקסימלי:
   </td>
   <td>
   <input type="text" name="Max_Workers" value="<%=Max_Workers %>" />
   </td>
   </tr>
   <tr>
   <td>
   מספר SMS להוספה
   </td>
   <td>
   <input type="text" name="Num_of_SMS" value="0" />
   </td>
   <td>
   <input type="text" readonly="readonly" name="C_Num_of_SMS" value="כרגע יש:<%=Num_Of_SMS %>" 
           style="border-style: none" />
   </td>
   </tr>
    <tr>
   <td>
   מספר תפקידים מקסימלי:
   </td>
   <td>
   <input type="text" name="Max_Jobs" value="<%=Max_Jobs %>" />
   </td>
   </tr>
   <tr>
   <td>תאריך תפוגה(הוספת ימים)</td>
   <td>
   <input type="text" name="Exp_days" value="0" />
   </td>
   <td>
   <input type="text" readonly="readonly" name="C_Exp_Date" value="<%=Exp_Date %>" 
           style="border-style: none" />
   </td>
    </tr>
    <tr>
    <td>
    <input type="submit" name="sub" value="עדכן" />
    </td>
    </tr>



   </table>
   </form>
</body>
</html>
