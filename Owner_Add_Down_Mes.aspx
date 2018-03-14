<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Owner_Add_Down_Mes.aspx.cs" Inherits="Owner_Add_Down_Mes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>הוספת הודעה חדשה</title>
</head>
<body dir="rtl">
    <form id="form1" action="Owner_Insert_Down_Mes.aspx" method="post">
    <table>
    <tr><td>
    הוספת הודעה חדשה
    </td></tr>
    <tr><td>
    מנהלים רואים:
    </td>
    <td>
        <input id="Checkbox1" name="admin" type="checkbox" />
    </td></tr>
    <tr><td>
    עובדים רואים:
    </td>
    <td>
    <input id="Checkbox2" name="worker" type="checkbox" />
    </td></tr>
    <tr>
    <td>
    הודעה:
    </td>
    <td>
        <textarea id="TextArea1" name="Msg" cols="40" rows="3" dir="rtl"></textarea>
    </td>
    </tr>
    <tr><td>
    לינק:
    </td>
    <td>
        <input id="Text1" name="link" type="text" />
    </td></tr>
    <tr><td>
        <input id="Submit1" name="sub" type="submit" value="הוסף" />
    </td></tr>
    </table>
    </form>
</body>
</html>
