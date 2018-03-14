<%@ Page Title="צור קשר" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #TextArea1
        {
            height: 276px;
            width: 384px;
        }
        #Submit1
        {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script type="text/javascript">
 function Check()
 {
 if (document.Make_Contact.Full_Name.value.length == 0) {
            document.Make_Contact.Full_Name.focus();
            alert("חובה למלא שם מלא");
            return false;
        }
        
         if (document.Make_Contact.Comment.value.length == 0) {
            document.Make_Contact.Comment.focus();
            alert("חובה למלא תוכן בהודעה");
            return false;
        }
         F = document.Make_Contact.E_Mail.value;
        i = F.indexOf('@');
        if (i == -1) {
            document.Make_Contact.E_Mail.focus();
            alert("כתובת דוא\"ל חייבת להכיל @");
            return false;
        }

        if (i == 0) {
            document.Make_Contact.E_Mail.focus();
            alert("כתובת דוא\"ל אינה יכולה להתחיל בכרוכית");
            return false;
        }

        if (F.lastIndexOf('@') == F.length - 1) {
            document.Make_Contact.E_Mail.focus();
            alert("כתובת דוא\"ל אינה יכולה להסתיים ב-@");
            return false;
        }

        if (F.lastIndexOf('@') > i) {
            document.Make_Contact.E_Mail.focus();
            alert("כתובת דוא\"ל אינה יכולה להכיל שתי @");
            return false;
        }
        if (document.Make_Contact.TO.selectedIndex == 0) {
            alert("חובה לבחור הפנייה להודעה");
            return false;
        }
        if (F.lastIndexOf('.') < i) {
            document.Make_Contact.E_Mail.focus();
            alert("חייבת להופיע נקודה אחרי @");
            return false;
        }

        if (F.charAt(F.length - 1) == '.') {
            document.Make_Contact.E_Mail.focus();
            alert("כתובת דוא\"ל אינה יכולה להסתיים בנקודה");
            return false;
        }

        if (F.indexOf("@.") > -1 || F.indexOf(".@") > -1) {
            document.Make_Contact.E_Mail.focus();
            alert("הנקודה אינה יכולה להיות צמודה ל@ ");
            return false;
        }

        if (CheckNameForLetterse(F)) {
            document.Make_Contact.E_Mail.focus();
            alert("כתובת הדוא\"ל מכילה תו לא חוקי");
            return false;
        }
        alert("הודעתך נשלחה בהצלחה!");
          return true;

      }
      function CheckNameForLetterse(Text) {
          var Let = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@";
          var tav, i;
          for (i = 0; i < Text.length; i++) {
              tav = Text.charAt(i);
              if (Let.indexOf(tav) == -1)
                  return false;
          }
          return true;
      }
 </script>
 <form id="form1" name ="Make_Contact" method="post" action="Send_Feedback.aspx" onsubmit="return Check();">
<table>
<tr><td colspan="2" align="center">
<h2>טופס יצירת קשר</h2>
</td></tr>
<tr>
<td colspan="2">
נשמח לעמוד אתכם בקשר ולענות לכל שאלה, בקשה, הצעה או תלונה.
<br />
צוות האתר ישתדל לענות בהקדם האפשרי ובאופן המספק ביותר עבור כל פנייה.
<br />

<br />
מלא את פרטי הטופס הבא:
</td></tr>
<tr>
<td>
    שם מלא:</td>
<td>
<input type ="text" name="Full_Name"/>
</td></tr>
<tr>
<td>
אימייל:
</td>
<td>
<input type ="text" name="E_Mail"/>
</td></tr>
<tr>
<td>
    הפנייה:</td>
<td>
    <select id="Select1" name="TO">
        <option>בחר</option>
        <option value="support@mishmaron.com">תמיכה טכנית</option>
        <option value="alon@mishmaron.com">שיווק ומכירות</option>
    </select>
    </td>
    </tr>
<tr>
<td>
תוכן הפניה:
</td>
<td>
    <textarea dir="rtl" id="TextArea1" name="Comment"></textarea>
</td></tr>
<tr>
<td colspan="2" style="text-align: center">
    <input id="Submit1" type="submit" name="unlog" value="שלח" /></td></tr>
</table>
</form>
</asp:Content>

