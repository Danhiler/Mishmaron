<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Owner_SendSMS.aspx.cs" Inherits="Owner_SendSMS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-weight: bold;
            text-decoration: underline;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 50%;" align="center" dir="rtl">
            <tr>
                <td class="style1" colspan="3">
                    <h1>
                        שליחת SMS</h1>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    מספר השולח:</td>
                <td colspan="2">
                    &nbsp;
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    מספר המקבל:</td>
                <td colspan="2">
                    &nbsp;
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;הודעה:
                </td>
                <td colspan="2">
                    &nbsp;
                    <asp:TextBox ID="TextBox3" runat="server" Height="106px" MaxLength="70" 
                        Width="205px" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="שלח" onclick="Button1_Click" />
               </td>
                <td>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
                <td>
                     <a href="Owner_Page.aspx">חזור לדף ראשי</a></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
