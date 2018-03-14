<%@ Page Title="שליחת שחזור ססמא" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Send_Lost_Password.aspx.cs" Inherits="Send_Lost_Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" language=javascript>
function cheak()
{
if(document.forgot_password.userid.value.length ==0)
{
document.forgot_password.userid.focus();
            alert("חובה למלא שם משתש");
            return false;
            

}
  if (document.forgot_password.userid.value.length < 3 || document.forgot_password.userid.value.length>15) {
            document.forgot_password.userid.focus();
            alert("שם משתמש חייב להיות בין 3 ל 15 תווים");
            return false;
        }
        if (CheckNameForLetterse(document.forgot_password.userid.value) == false) {
            document.forgot_password.userid.focus();
            alert("נא השתמש באותיות באנגלית בלבד בשם משתמש");
            return false;
        }
return true;

}
    function CheckNameForLetterse(Text) {
        var Let = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        var tav, i;
        for (i = 0; i < Text.length; i++) {
            tav = Text.charAt(i);
            if (Let.indexOf(tav) == -1)
                return false;
        }
        return true;
    }
</script>

        <asp:Label ID="Label1" runat="server" name="lable1" Font-Bold="True" 
        Font-Size="Medium" ForeColor="Red"></asp:Label>
        <br />
<form name="forgot_password" method="post" onsubmit="retunr cheak();" action="Send_Lost_Password.aspx">
    <table style="width:100%;">
        <tr>
            <td colspan="3">
                שכחת את הססמא?
                <br />
                 לא נורא, רשום את שם המשתמש שלך והססמא תשלח אוטומטית למייל שלך</td>
        </tr>
        <tr>
            <td>
                שם משתמש:</td>
            <td colspan="2">
                <input id="Text1" type="text" name="userid" /></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td >
                <input id="Submit1" type="submit" name="send" value="שלח" /></td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </form>
</asp:Content>

