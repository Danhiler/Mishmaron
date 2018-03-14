<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoginCheck.aspx.cs" Inherits="LoginCheck" Title="התחברות" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" language="javascript">
    function Check() {
        if (document.LoginForm.UN.value.length == 0) {
            document.LoginForm.UN.focus();
            alert("חובה למלא שם משתש");
            return false;
        }

        if (document.LoginForm.UN.value.length < 3 || document.LoginForm.UN.value.length > 15) {
            document.LoginForm.UN.focus();
            alert("שם משתמש חייב להיות בין 3 ל 15 תווים");
            return false;
        }
        if (CheckNameForLetterse(document.LoginForm.UN.value) == false) {
            document.LoginForm.UN.focus();
            alert("נא השתמש באותיות באנגלית בלבד בשם משתמש");
            return false;

        }
        var F = document.LoginForm.Passw.value;

        if (CheckNameForLetterse(F) == false) {
            document.LoginForm.Passw.focus();
            alert("נא השתמש באותיות באנגלית ומספרים בלבד בססמא");
            return false;
        }
        if (F.length < 4 || F.length > 15) {
            document.LoginForm.Passw.focus();
            alert("אורך הססמה צריך להיות בין 4 ל15 תווים");
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
    <table>
    <tr>
    <td>
    <h2>התחברות</h2>
    </td>
    </tr>
    <tr><td>
    על מנת להתחבר, אנא הקלד שם משתמש וססמא
    </td></tr>
    <tr><td>
     <asp:Label ID="Label1" runat="server" name="lable1" Font-Bold="True" 
        Font-Size="Medium" ForeColor="Red"></asp:Label>
    </td></tr>
    </table>

   
    <form method="post" action="LoginCheck.aspx"  onsubmit="return Check();" name ="LoginForm" >
    <table  >
        <tr><td colspan="2">להתחברות
            </td>
        </tr>
        <tr>
            <td>שם משתמש</td>
            <td><input type="text" style="width: 108px" name="UN"/></td>
        </tr>
        <tr>
            <td>ססמא</td>
            <td><input type="password" style="width: 107px" name="Passw"/></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <input id="Submit1" type="submit" value="אשר" />
             </td>
         </tr>
       
                 <tr>
            <td colspan="2" style="text-align: center">
                <a href="Lost_Password.aspx" >שכחת ססמא?</a>
                </td>
               
         </tr>
    </table>
   </form>
</asp:Content>

